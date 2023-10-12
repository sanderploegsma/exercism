typealias Wires = (String, String, String)

let flip: (Wires) -> Wires = { ($0.1, $0.0, $0.2) }

let rotate: (Wires) -> Wires = { ($0.1, $0.2, $0.0) }

func makeShuffle(
  flipper: @escaping (Wires) -> Wires,
  rotator: @escaping (Wires) -> Wires
) -> (UInt8, Wires) -> Wires {
  { (id: UInt8, wires: Wires) -> Wires in
    let bits = (0...7).map { (id >> $0) & 1 }

    return bits.reduce(wires) { (acc, bit) in 
      bit == 0 ? flipper(acc) : rotator(acc)
    }
  } 
}
