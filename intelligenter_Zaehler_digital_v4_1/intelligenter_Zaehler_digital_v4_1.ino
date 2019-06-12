//-----------------------------------------------------
/*Studienarbeit 2 intelligenter Stromzähler v4
Versionsbeschreibung:
v4.1: Ergänzung der automatischen WLAN Suche
v4: Erweiterung von v2 um v3
v3: Standalone Software zur Speicherung von Zugangsdaten auf dem ESP8266
mittels serieller Kommunikation
v2: Erweiterung von v1 um ThingSpeak Integration
v1: elementares Auswerten des Stromzählers
*/
//-----------------------------------------------------

//-----------------------------------------------------
/*
*/
//-----------------------------------------------------

#include <Arduino.h>
#include "ESP8266WiFi.h"
#include <PubSubClient.h>
#include <FS.h>

#define STX "\x02"                      //ASCII-Code 02, text representation of the STX code
#define ETX "\x03"                      //ASCII-Code 03, text representation of the ETX code
#define RS  ";"                         //Used as RS code

WiFiClient client; //Initialisierung der WiFiClient Bibliothek
PubSubClient mqttClient(client); // Initialisierung der PubSubClient Bibliothek

//-----------------------------------------------------
/*
Zählvariablen, Hilfsvariablen etc.
*/
//-----------------------------------------------------
int wlanCct = 0; //wlan Cycle Count
int pwLength = 0; //String Länge
unsigned long pcComInitTime = 15L * 1000L; //20sek. Initialisierungszeit für PC Verbindung
unsigned long pcComCompTime = 0;  //Zeitvariable für Differenzbildung mit millis Fkt.
bool pcMode = false;

//-----------------------------------------------------
/*
Stromzähler bezogene Variablen
*/
//-----------------------------------------------------
//int j = 0;
int verbrauch_index = 0;
char sequenzLaengeVerbrauch;
char sequenzLaengeLeistung;
char incomingByte[200];
char payload[4];
char MusterLeistung[5] = {0, 98, 27, 82, 254}; //Vergleichswerte, die anzeigen, dass eine Leistungsangabe folgt
char MusterVerbrauch[5] = {0, 98, 30, 82, 255};  //Vergleichswerte, die anzeigen, dass eine Verbrauchsangabe folgt
float WirkVerbrauch;
float WirkLeistung;

//#include <util/delay.h>

//-----------------------------------------------------
/*
Variablendeklaration und Initialisierung für 
die Sicherung der Zugangsdaten im Flash Speicher des
ESP8266
*/
//-----------------------------------------------------
char inByte;
String inData[100];
String instruction;
String message;
int i = 0;
int j =0;
int ninByte;
bool newSerialDat = false;
bool newInstruction = false;

//-----------------------------------------------------
/*
Variablen der Zugangsdaten
*/
//-----------------------------------------------------
String tsWLANSSID;      //WLAN SSID
String tsWLANpasswort;  //Passwort zu gewählter SSID
String tsmqttPass;      //ThingSpeak MQTT API Key
String tsmqttApik;      //ThingSpeak Channel Write API Key
String tschnlID;        //ThingSpek Channel ID

//-----------------------------------------------------
/*
Variablen für Zugangsdaten mit Verbindung zu MQTT.
Diese werden auch Übertragen
*/
//-----------------------------------------------------
char ssid[50] = "SSID"; // Wlan SSID
char password[50] = "PASSWORD"; // Wlan Passwort


const char* server = "mqtt.thingspeak.com"; 
char mqttUserName[50] = "TSArduinoMQTTDemo";  //Hier kann ein Name frei gewählt werden
char mqttPass[50] = "";  // MQTT API-Key
char writeAPIKey[50] = "";    // Write-API Key des Channels (Schreibberechtigung)
long channelID = 000000;

//-----------------------------------------------------
/*
Variablen für ThingSpeak MQTT Funktionen
*/
//-----------------------------------------------------
unsigned long lastConnectionTime = 0; 
const unsigned long postingInterval = 20L * 1000L; // Versenden einer Nachricht alle 20 Sek

int fieldsToPublish[8]={1,1,0,0,0,0,0,0};           //Zielfelder von ThingSpeak Channel auswählen
float dataToPublish[8];     //Feld, in das später die Daten zur veröffentlichung geschrieben werden


//-----------------------------------------------------
/*
Funktionsdeklaration für die Zuweisung und Speicherung der
verschiedenen Passwörter
Funktionsdeklaration für den Abruf der verschiedenen PW
*/
//-----------------------------------------------------
void searchWLAN(void);      //WLAN Suche
void setWLANSSID(void);     //WLAN SSID 
void setWLAN (void);        //WLAN Passwort
void setmqttPass (void);    //mqtt Passwort
void setmqttApik (void);    //mqtt writeAPIKey
void setchnlID (void);      //ThingSpeak channel ID

void getPW (void);

//-----------------------------------------------------
/*
Funktionsdeklaration für den Auswertealgorithmus für serielle Daten
aus der Desktopsoftware
Aufbau einer Nachricht:
1.instruction + message
oder
2.instruction
Dabei besteht eine instruction immer aus 8 Zeichen
*/
//-----------------------------------------------------
void computeSerialData(void);

//-----------------------------------------------------
/*
Funktionsdeklaration für das zyklische Prüfen auf Daten an der seriellen Schnittstelle
*/
//-----------------------------------------------------
void checkSerialDataAvblty(void);

//-----------------------------------------------------
/*
Funktionsdeklaration für die Entscheidung einer PC Verbindung
oder dem Standalone Stromzähler Betrieb
*/
//-----------------------------------------------------
void checkPCMode(void);

//-----------------------------------------------------
/*
Funktionsdeklaration Stromzählerdaten
*/
//-----------------------------------------------------
void energyCounterData(void);

//-----------------------------------------------------
/*
Funktionsdeklaration ThingSpeak MQTT Funktionen
*/
//-----------------------------------------------------
void mqConnect();
void getID(char clientID[], int idLength);
void mqttPublish(long pubChannelID, char* pubWriteAPIKey, float dataArray[], int fieldArray[]);


void setup() {
  Serial.begin(9600);
  SPIFFS.begin();
  delay(1500);
  WiFi.disconnect();
  delay(100);
  
  //
  checkPCMode();

  pinMode(LED_BUILTIN, OUTPUT);
  digitalWrite(LED_BUILTIN, LOW);

  int status = WL_IDLE_STATUS; 
  WiFi.mode(WIFI_STA);
  WiFi.disconnect();
  delay(100);
  

  //
  getPW();
  
  
  Serial.print(ssid);
  Serial.print(password);

  wlanCct=0;
  while ((status != WL_CONNECTED) && (!pcMode)) //Verbindungsaufbau zum Wlan-Netzwerk
  {
    wlanCct++;
    status = WiFi.begin(ssid, password);
    Serial.println(".");
    delay(5000);
    if(wlanCct > 5){
      pcMode = true;
    }
  }
  Serial.println("Connected to wifi");    //Ausgabe von Wlan Statusinformationen
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
  mqttClient.setServer(server, 1883);   // MQTT Server hinterlegen
  
  Serial.print("Setup done");
  j=0;
  delay(200);
}

void loop() {
  //_delay_ms(50);
  if(pcMode){
    computeSerialData();
  }

  //Zuordnung der verschiedenen Nachrichten mit Hilfe der Anweisungen
  //ein Zusatzbyte verhindert die zyklische Neubeschreibung der letzten 
  //übertragenen Variable
  if((instruction == "comInit#") && (newInstruction == true) && pcMode){
    Serial.print(STX);
    Serial.print(instruction);
    Serial.print(ETX);
    delay(1000);
    newInstruction = false;
  }
  if((instruction == "WLSEARCH") & (newInstruction == true) && pcMode){
    searchWLAN();
  }
  if((instruction == "WLANSSID") & (newInstruction == true) && pcMode){
    setWLANSSID();
  }
  if((instruction == "WLANPSWD") && (newInstruction == true) && pcMode){
    setWLAN();
  }
  if((instruction == "mqttPass") && (newInstruction == true) && pcMode){
    setmqttPass();
  }
  if((instruction == "mqttApik") && (newInstruction == true) && pcMode){
    setmqttApik();
  }
  if((instruction == "chnlID##") && (newInstruction == true) && pcMode){
    setchnlID();
  }

  
  if(pcMode){
    checkSerialDataAvblty();
  }
  //--------------------------------------------------------------
  //Ende PC Mode
  //--------------------------------------------------------------
  if(!pcMode){
    energyCounterData();
    if (!mqttClient.connected()) //Vor dem Versenden / publishen der MQTT Nachrichten wird geprüft, ob eine Verbindung zum MQTT-Broker besteht.
    {
      mqConnect();
    }
    mqttClient.loop();
    if (millis() - lastConnectionTime > postingInterval)  //Ist das Zeitintervall überschritten, werden die aktuellsten Daten an den Broker übermittelt.
    {
    
      dataToPublish[0] = WirkVerbrauch;
      dataToPublish[1] = WirkLeistung;
      delay(1);
      mqttPublish( channelID, writeAPIKey, dataToPublish, fieldsToPublish);
    }  
  }

}

//-----------------------------------------------------
/*
PW werden aus Flash Speicher ausgelesen und in Variablen-Arrays für die
Übertragung geschrieben.
*/
//-----------------------------------------------------
void getPW(){

  File fwlanSSID = SPIFFS.open("/wlanSSID.txt", "r");
  if(!fwlanSSID){
    Serial.print("file open failed");
  }
  tsWLANSSID = fwlanSSID.readString();
  fwlanSSID.close();
  Serial.print(tsWLANSSID);
  delay(200);
  memset(ssid, 0, sizeof(ssid));
  pwLength = tsWLANSSID.length();
  for(int z=0; z<=pwLength; z++){
    ssid[z] = tsWLANSSID[z];
    //Serial.print(password[z]);
  }

  File fwlanPasswort = SPIFFS.open("/wlanpasswort.txt", "r");
  if(!fwlanPasswort){
    Serial.print("file open failed");
  }
  tsWLANpasswort = fwlanPasswort.readString();
  fwlanPasswort.close();
  Serial.print(tsWLANpasswort);
  delay(200);
  memset(password, 0, sizeof(password));
  pwLength = tsWLANpasswort.length();
  for(int z=0; z<=pwLength; z++){
    password[z] = tsWLANpasswort[z];
    //Serial.print(password[z]);
  }
  
  //Serial.println("WLANPSWD ausgegeben");
  //Serial.println(password);

  File fmqttPass = SPIFFS.open("/setmqttPass.txt", "r");
  if(!fmqttPass){
    Serial.print("file open failed");
  }
  tsmqttPass = fmqttPass.readString();
  fmqttPass.close();
  Serial.print(tsmqttPass);
  delay(200);
  memset(mqttPass, 0, sizeof(mqttPass));
  pwLength = tsmqttPass.length();
  for(int z=0; z<=pwLength; z++){
    mqttPass[z] = tsmqttPass[z];
    //Serial.print(mqttPass[z]);
  }
  //Serial.println("MQTT PSWD ausgegeben");
  //Serial.println(password);

  File fmqttApik = SPIFFS.open("/setmqttApik.txt", "r");
  if(!fmqttApik){
    Serial.print("file open failed");
  }
  tsmqttApik = fmqttApik.readString();
  fmqttApik.close();
  Serial.print(tsmqttApik);
  delay(200);
  memset(writeAPIKey, 0, sizeof(writeAPIKey));
  pwLength = tsmqttApik.length();
  for(int z=0; z<=pwLength; z++){
    writeAPIKey[z] = tsmqttApik[z];
    //Serial.print(writeAPIKey[z]);
  }
  //Serial.println("MQTT API KEy ausgegeben");
  //Serial.println(password);

  File fchnlID = SPIFFS.open("/setchnlID.txt", "r");
  if(!fchnlID){
    Serial.print("file open failed");
  }
  tschnlID = fchnlID.readString();
  fchnlID.close();
  Serial.print(tschnlID);
  delay(200);
  int cacheCHNLID = tschnlID.toInt();
  channelID = (long)cacheCHNLID;
  //Serial.println("CHNL ID ausgegeben");
  //Serial.println(password); */

}

void checkPCMode(){
  pcComCompTime = millis();
  while((millis() - pcComCompTime < pcComInitTime) && (!pcMode)){
    Serial.print(STX);
    Serial.print("#PCMode#");
    Serial.print(ETX);
    delay(1000);
    if(Serial.available() > 0){
      newSerialDat = true;
    i=0;
    while(Serial.available()){
      digitalWrite(LED_BUILTIN, HIGH);
      delay(10);
      digitalWrite(LED_BUILTIN, LOW);
      delay(10);
      inByte = Serial.read();
      inData[i] = inByte;
      i++;

    }
    ninByte = i;
    //delay(100);
    }
    computeSerialData();
    if((instruction == "#PCMode#") && (newInstruction == true)){
      //Serial.print(STX);
      //Serial.print("PC Mode aktiv");
      //Serial.print(ETX);
      //Serial.println("PC Mode aktiv");
      pcMode = true;
    }
  }
}

//-----------------------------------------------------
/*

*/
//-----------------------------------------------------
void computeSerialData(){

  if (newSerialDat == true) {
    instruction = "";
    message = "";
    i = 0;
    if(ninByte > 8){
      while(i < 8){
        instruction += inData[i];
        i++;
      }
      while((i >= 8) & (i <= ninByte)){
        
        message += inData[i];
        
        i++;
      }

    }
    else{
      while(i < ninByte){
        instruction += inData[i];
        i++;  
      }
    }
    
    newSerialDat = false;
    newInstruction = true;
  }

}

//-----------------------------------------------------
/*

*/
//-----------------------------------------------------
void checkSerialDataAvblty(){

  if(Serial.available()>0){
    
    newSerialDat = true;
    i=0;
    memset(inData, 0, sizeof(inData));
    while(Serial.available()){
      digitalWrite(LED_BUILTIN, HIGH);
      delay(10);
      digitalWrite(LED_BUILTIN, LOW);
      delay(10);
      inByte = Serial.read();
      inData[i] = inByte;
      i++;

    }
    ninByte = i;
    delay(100);
    //Serial.print(STX);
    //Serial.print(ninByte);
    //Serial.print(ETX);
    delay(300);
  }

}

//-----------------------------------------------------
/*

*/
//-----------------------------------------------------
void searchWLAN(){
  int n = WiFi.scanNetworks();
  if (n == 0) {
    Serial.print(STX);
    Serial.print("Keine Netzwerke gefunden!");
    Serial.print(ETX);
  } 
  else {
    Serial.print(STX);
    Serial.print(instruction);
    Serial.print(RS);
    for (int q = 0; q < n; ++q) {
      Serial.print(WiFi.SSID(q));
      Serial.print(RS);
      delay(5);
    }
    Serial.print(ETX);
    newInstruction = false;
    delay(10);        
  }


}

//-----------------------------------------------------
/*

*/
//-----------------------------------------------------
void setWLANSSID(){

  Serial.print(STX);
  Serial.print(instruction + message);
  Serial.print(ETX);
  delay(1000);

  File wlanSSID = SPIFFS.open("/wlanSSID.txt", "w");
  if (!wlanSSID) {
    Serial.println("file open failed");
  }
  wlanSSID.print(message);
  wlanSSID.close();
  //Serial.print(STX);
  //Serial.print(ninByte);
  //Serial.print(ETX);
  newInstruction = false;
}

//-----------------------------------------------------
/*

*/
//-----------------------------------------------------
void setWLAN(){

  Serial.print(STX);
  Serial.print(instruction + message);
  Serial.print(ETX);
  delay(1000);

  File wlanPasswort = SPIFFS.open("/wlanpasswort.txt", "w");
  if (!wlanPasswort) {
    Serial.println("file open failed");
  }
  wlanPasswort.print(message);
  wlanPasswort.close();
  //Serial.print(STX);
  //Serial.print(ninByte);
  //Serial.print(ETX);
  newInstruction = false;

}

//-----------------------------------------------------
/*

*/
//-----------------------------------------------------
void setmqttPass(){

  Serial.print(STX);
  Serial.print(instruction + message);
  Serial.print(ETX);
  delay(1000);

  File mqttPass = SPIFFS.open("/setmqttPass.txt", "w");
  if (!mqttPass) {
    Serial.println("file open failed");
  }
  mqttPass.print(message);
  mqttPass.close();
  //Serial.print(STX);
  //Serial.print(ninByte);
  //Serial.print(ETX);
  newInstruction = false;

}

//-----------------------------------------------------
/*

*/
//-----------------------------------------------------
void setmqttApik(){

  Serial.print(STX);
  Serial.print(instruction + message);
  Serial.print(ETX);
  delay(1000);

  File mqttApik = SPIFFS.open("/setmqttApik.txt", "w");
  if (!mqttApik) {
    Serial.println("file open failed");
  }
  mqttApik.print(message);
  mqttApik.close();
  //Serial.print(STX);
  //Serial.print(ninByte);
  //Serial.print(ETX);
  newInstruction = false;

}

//-----------------------------------------------------
/*

*/
//-----------------------------------------------------
void setchnlID(){

  Serial.print(STX);
  Serial.print(instruction + message);
  Serial.print(ETX);
  delay(1000);

  File chnlID = SPIFFS.open("/setchnlID.txt", "w");
  if (!chnlID) {
    Serial.println("file open failed");
  }
  chnlID.print(message);
  chnlID.close();
  //Serial.print(STX);
  //Serial.print(ninByte);
  //Serial.print(ETX);
  newInstruction = false;

}

void energyCounterData(){
  if (Serial.available() > 0) {        //Sobald eine Nachricht an der seriellen Schnittstelle ankommt, startet die Verarbeitung
    for (int i = 1; i < 200; i++) {
      incomingByte[i] = Serial.read();    //Einlesen der Daten von der seriellen Schnittstelle
    }
  }
  j = 1;
  while (j < 200){
    if((incomingByte[j] == MusterVerbrauch[0]) && 
    (incomingByte[j + 1] == MusterVerbrauch[1]) && 
    (incomingByte[j + 2] == MusterVerbrauch[2]) && 
    (incomingByte[j + 3] == MusterVerbrauch[3]) && 
    (incomingByte[j + 4] == MusterVerbrauch[4])){
      verbrauch_index = j;    //Vergleich der eingelesenen Daten mit dem Muster für den Wirkverbrauch
       j = j + 5;
       sequenzLaengeVerbrauch = incomingByte[j];    //Vorbereitung für den Auswertealgorithmus
       j=199;
    }
    j++;
    //Serial.print(incomingByte[j]);
    //Serial.print(" ");  //Serielle Ausgabe für Debugging
  }
  if (j == 199) {
    Serial.println("FEHLER");
  }
  else {
    //verbrauch_index = j;
    //j = j + 5;
    //sequenzLaenge = incomingByte[j];
    if(sequenzLaengeVerbrauch == 99){     //Algorithmus zur Auswertung des Verbrauchs. Aktuell werden nur Werte bis zu einer bestimmten Bytelänge ausgewertet. -> Erweiterung in kommender Arbeit
      payload[1] = incomingByte[verbrauch_index + 6];
      payload[2] = incomingByte[verbrauch_index + 7];
      //Serial.print(payload[1]);
      WirkVerbrauch = payload[1];
      WirkVerbrauch = WirkVerbrauch * 256 + payload[2];
      WirkVerbrauch = WirkVerbrauch / 10000;
      Serial.println("Verbrauch: ");
      Serial.print(WirkVerbrauch);
      Serial.print(" kWh");
      Serial.println(); 
    }
    }

    
    j = 1;
    while (j < 200){
      if((incomingByte[j] == MusterLeistung[0]) && 
      (incomingByte[j + 1] == MusterLeistung[1]) && 
      (incomingByte[j + 2] == MusterLeistung[2]) && 
      (incomingByte[j + 3] == MusterLeistung[3]) && 
      (incomingByte[j + 4] == MusterLeistung[4])){
        verbrauch_index = j;    //Vergleich der eingelesenen Daten mit dem Muster für die aktuelle Leistung
        j = j + 5;
        sequenzLaengeLeistung = incomingByte[j];    //identische Funktionen, wie bei der Auswertung des Wirkverbrauches
        j=199;
      }
      j++;
      //Serial.print(incomingByte[j]);
      //Serial.print(" ");
    }
    if (j == 199) {
      Serial.println("FEHLER");
    }
    else {

      if(sequenzLaengeLeistung == 82){    //Der Algorithmus unterstützt das Auswerten von Verbräuchen bis zu 168kW. 
        WirkLeistung = 0;
        Serial.println("Leistung: ");
        Serial.print(WirkLeistung);
        Serial.print(" W");
        Serial.println();
      }
      if(sequenzLaengeLeistung == 83){
        payload[1] = incomingByte[verbrauch_index + 6];
        payload[2] = incomingByte[verbrauch_index + 7];
        WirkLeistung = payload[1];
        WirkLeistung = WirkLeistung * 256 + payload[2];
        WirkLeistung = WirkLeistung / 100;
        Serial.println("Leistung: ");
        Serial.print(WirkLeistung);
        Serial.print(" W");
        Serial.println();
      }
      if(sequenzLaengeLeistung == 84){
        payload[1] = incomingByte[verbrauch_index + 6];
        payload[2] = incomingByte[verbrauch_index + 7];
        payload[3] = incomingByte[verbrauch_index + 8];
        WirkLeistung = payload[1];
        WirkLeistung = WirkLeistung * 256 + payload[2];
        WirkLeistung = WirkLeistung * 256 + payload[3];
        WirkLeistung = WirkLeistung / 100;
        Serial.println("Leistung: ");
        Serial.print(WirkLeistung);
        Serial.print(" W");
        Serial.println();
      }
  }
}


//MQTT Thingspeak Verbindung:
void mqConnect()   //Funktion wird genutzt, um eine Verbindung mit dem MQTT Broker aufzubauen
{
    char clientID[ 9 ];
    
   
    while ( !mqttClient.connected() )
    {

        getID(clientID,8);
       
        // Connect to the MQTT broker.
        Serial.print( "Attempting MQTT connection..." );
        if ( mqttClient.connect( clientID, mqttUserName, mqttPass ) ) //Übergabe der Parameter Nutzeridentifikation und einem Passwort 
        {
            Serial.println( "Connected with Client ID:  " + String( clientID ) + " User "+ String( mqttUserName ) + " Pwd "+String( mqttPass ) );
           
        } else
        {
            Serial.print( "failed, rc = " );
            // See http://pubsubclient.knolleary.net/api.html#state for the failure code explanation.
            Serial.print( mqttClient.state() );
            Serial.println( " Will try again in 5 seconds" );
            delay( 5000 );
        }
    }
}

void getID(char clientID[], int idLength){   // Aufruf aus der Verbindungsfunktion. Es wird eine zufällige ID zur Identifikation erstellt.
static const char alphanum[] ="0123456789"
"ABCDEFGHIJKLMNOPQRSTUVWXYZ"
"abcdefghijklmnopqrstuvwxyz";                        

    // Generate ClientID
    for (int i = 0; i < idLength ; i++) {
        clientID[ i ] = alphanum[ random( 51 ) ];
    }
    clientID[ idLength ] = '\0';
    
}

void mqttPublish(long pubChannelID, char* pubWriteAPIKey, float dataArray[], int fieldArray[]) {    //Funktion zum publishen der Daten.
    int index=0;
    String dataString="";
    
   
    while (index<8){
        
       
        if (fieldArray[ index ]>0){
          
            dataString+="&field" + String( index+1 ) + "="+String( dataArray [ index ] ); //alle Felder und deren Inhalt werden in einer Variable zusammengefasst.
        }
        index++;
    }
    
    Serial.println( dataString );
    
   
    String topicString ="channels/" + String( pubChannelID ) + "/publish/"+String( pubWriteAPIKey );  //Festlegung eines Topics zur Veröffentlichung der Daten. Gebildet aus: Schreibberechtigung und der ID des ThingSpeak Channels
    mqttClient.publish( topicString.c_str(), dataString.c_str() );    //Publishen der Daten in zugehörigem Topic
    Serial.println( "Pubished to channel " + String( pubChannelID ) );
    lastConnectionTime = millis();    //Zurücksetzen des Zeitintervalls für die nächste Übertragung.
}

