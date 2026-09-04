// JOYSTICK 1
const int JOY1_UP    = 2;
const int JOY1_DOWN  = 3;
const int JOY1_LEFT  = 4;
const int JOY1_RIGHT = 5;

// KNOPPEN
const int BUTTON1 = 6;
const int BUTTON2 = 7;
const int BUTTON3 = 12;
const int BUTTON4 = 13;//do not use
const int BUTTON5 = A0;
const int BUTTON6 = A1;

// JOYSTICK 2
const int JOY2_UP    = 8;
const int JOY2_DOWN  = 9;
const int JOY2_LEFT  = 10;
const int JOY2_RIGHT = 11;

void setup() {

  // Joystick 1
  pinMode(JOY1_UP, INPUT_PULLUP);
  pinMode(JOY1_DOWN, INPUT_PULLUP);
  pinMode(JOY1_LEFT, INPUT_PULLUP);
  pinMode(JOY1_RIGHT, INPUT_PULLUP);

  // Joystick 2
  pinMode(JOY2_UP, INPUT_PULLUP);
  pinMode(JOY2_DOWN, INPUT_PULLUP);
  pinMode(JOY2_LEFT, INPUT_PULLUP);
  pinMode(JOY2_RIGHT, INPUT_PULLUP);

  // Knoppen
  pinMode(BUTTON1, INPUT_PULLUP);
  pinMode(BUTTON2, INPUT_PULLUP);
  pinMode(BUTTON3, INPUT_PULLUP);
  pinMode(BUTTON4, INPUT_PULLUP);
  pinMode(BUTTON5, INPUT_PULLUP);
  pinMode(BUTTON6, INPUT_PULLUP);

  Serial.begin(115200);
}

void loop() {

  // Joystick 1
  int joy1_up    = !digitalRead(JOY1_UP);
  int joy1_down  = !digitalRead(JOY1_DOWN);
  int joy1_left  = !digitalRead(JOY1_LEFT);
  int joy1_right = !digitalRead(JOY1_RIGHT);

  // Joystick 2
  int joy2_up    = !digitalRead(JOY2_UP);
  int joy2_down  = !digitalRead(JOY2_DOWN);
  int joy2_left  = !digitalRead(JOY2_LEFT);
  int joy2_right = !digitalRead(JOY2_RIGHT);

  // Knoppen
  int button1 = !digitalRead(BUTTON1);
  int button2 = !digitalRead(BUTTON2);
  int button3 = !digitalRead(BUTTON3);
  int button4 = !digitalRead(BUTTON4);
  int button5 = !digitalRead(BUTTON5);
  int button6 = !digitalRead(BUTTON6);

  // Verstuur alles naar de PC
  Serial.print(joy1_up);
  Serial.print(",");
  Serial.print(joy1_down);
  Serial.print(",");
  Serial.print(joy1_left);
  Serial.print(",");
  Serial.print(joy1_right);
  Serial.print(",");

  Serial.print(joy2_up);
  Serial.print(",");
  Serial.print(joy2_down);
  Serial.print(",");
  Serial.print(joy2_left);
  Serial.print(",");
  Serial.print(joy2_right);
  Serial.print(",");

  Serial.print(button1);
  Serial.print(",");
  Serial.print(button2);
  Serial.print(",");
  Serial.print(button3);
  Serial.print(",");
  Serial.print(button4);
  Serial.print(",");
  Serial.print(button5);
  Serial.print(",");
  Serial.println(button6);

  delay(10);
}
