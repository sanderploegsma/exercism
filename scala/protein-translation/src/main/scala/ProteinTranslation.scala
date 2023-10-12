object ProteinTranslation {
  def proteins(seq: String): Seq[String] = {
    seq.grouped(3).map(translate).takeWhile(_ != "STOP").toSeq
  }

  private def translate(codon: String): String = codon match {
    case "AUG" => "Methionine"
    case "UUU" | "UUC" => "Phenylalanine"
    case "UUA" | "UUG" => "Leucine"
    case "UCU" | "UCC" | "UCA" | "UCG" => "Serine"
    case "UAU" | "UAC" => "Tyrosine"
    case "UGU" | "UGC" => "Cysteine"
    case "UGG" => "Tryptophan"
    case "UAA" | "UAG" | "UGA" => "STOP"
    case _ => throw new IllegalArgumentException()
  }
}