import serial
from pynput.keyboard import Controller, Key

# =========================
# INSTELLINGEN
# =========================

COM_PORT = "COM4"
BAUD_RATE = 115200

# =========================
# ARDUINO VERBINDEN
# =========================

print("Arduino verbinden...")

arduino = serial.Serial(
    COM_PORT,
    BAUD_RATE,
    timeout=0.1
)

keyboard = Controller()

print("Arduino verbonden!")
print("Arcade controller actief.")
print("Druk CTRL+C om te stoppen.")

# Houd bij welke toetsen momenteel ingedrukt zijn
pressed = set()


def press_key(key):
    if key not in pressed:
        keyboard.press(key)
        pressed.add(key)


def release_key(key):
    if key in pressed:
        keyboard.release(key)
        pressed.remove(key)


try:

    while True:

        line = arduino.readline().decode("utf-8").strip()

        if not line:
            continue

        values = line.split(",")

        if len(values) != 14:
            continue

        # Arduino data omzetten naar integers
        values = [int(x) for x in values]

        # =========================
        # JOYSTICK 1
        # =========================

        joy1_up    = values[0]
        joy1_down  = values[1]
        joy1_left  = values[2]
        joy1_right = values[3]

        # =========================
        # JOYSTICK 2
        # =========================

        joy2_up    = values[4]
        joy2_down  = values[5]
        joy2_left  = values[6]
        joy2_right = values[7]

        # =========================
        # KNOPPEN
        # =========================

        button1 = values[8]
        button2 = values[9]
        button3 = values[10]
        button4 = values[11]
        button5 = values[12]
        button6 = values[13]

        # =========================
        # JOYSTICK 1 → WASD
        # =========================

        if joy1_up:
            press_key("0")
        else:
            release_key("0")

        if joy1_down:
            press_key("w")
        else:
            release_key("w")

        if joy1_left:
            press_key("9")
        else:
            release_key("9")

        if joy1_right:
            press_key("q")
        else:
            release_key("q")

        # =========================
        # JOYSTICK 2 → PIJLTJES
        # =========================

        if joy2_up:
            press_key(Key.up)
        else:
            release_key(Key.up)

        if joy2_down:
            press_key(Key.down)
        else:
            release_key(Key.down)

        if joy2_left:
            press_key("a")
        else:
            release_key("a")

        if joy2_right:
            press_key("s")
        else:
            release_key("s")

        # =========================
        # ARCADE KNOPPEN
        # =========================

        if button1:
            press_key("e")
        else:
            release_key("e")

        if button2:
            press_key("r")
        else:
            release_key("r")

        if button3:
            press_key("d")
        else:
            release_key("d")

        if button4:
            press_key("8")
        else:
            release_key("8")

        if button5:
            press_key("f")
        else:
            release_key("f")

        if button6:
            press_key("g")
        else:
            release_key("g")


except KeyboardInterrupt:

    print("\nController gestopt.")

finally:

    # Zorg dat alle toetsen worden losgelaten
    for key in list(pressed):
        keyboard.release(key)

    arduino.close()

    print("Arduino verbinding gesloten.")
