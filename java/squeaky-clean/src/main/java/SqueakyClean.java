class SqueakyClean {
    static String clean(String identifier) {
        var sanitized = identifier.replaceAll("[α-ω]", "");

        var builder = new StringBuilder();
        var isKebab = false;
        for (int i = 0; i < sanitized.length(); i++) {
            var c = sanitized.charAt(i);

            if (Character.isSpaceChar(c)) {
                builder.append('_');
            }

            if (Character.isISOControl(c)) {
                builder.append("CTRL");
                continue;
            }

            if (c == '-') {
                isKebab = true;
                continue;
            }

            if (Character.isLetter(c)) {
                builder.append(isKebab ? Character.toUpperCase(c) : c);
                isKebab = false;
            }
        }

        return builder.toString();
    }
}
