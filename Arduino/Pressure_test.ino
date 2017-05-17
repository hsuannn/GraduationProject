#define led_pin 11
#define fsr_pin A0

void setup()
{
  Serial.begin(115200);
//  pinMode(led_pin, OUTPUT);
}

void loop()
{
  int fsr_value = analogRead(fsr_pin); // 讀取FSR
 // int led_value = map(fsr_value, 0, 1023, 0, 255); // 從0~1023映射到0~255
  if(fsr_value!=0){
 //   Serial.println(fsr_value);
    Serial.write(1);
    Serial.flush();
    delay(20);
  }
 // delay(2000);
//  analogWrite(led_pin, 0);
}
