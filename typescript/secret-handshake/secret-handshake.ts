const Wink = 0b00001;
const DoubleBlink = 0b00010;
const CloseYourEyes = 0b00100;
const Jump = 0b01000;
const Reverse = 0b10000;

const commands = {
  wink: Wink,
  "double blink": DoubleBlink,
  "close your eyes": CloseYourEyes,
  jump: Jump,
};

export default class Handshake {
  constructor(private input: number) {}

  private isEnabled = (mask: number) => (this.input & mask) > 0;

  public commands(): string[] {
    const cmds = Object.entries(commands)
      .filter(([, mask]) => this.isEnabled(mask))
      .map(([cmd]) => cmd);

    if (this.isEnabled(Reverse)) {
      return cmds.reverse();
    }

    return cmds;
  }
}
