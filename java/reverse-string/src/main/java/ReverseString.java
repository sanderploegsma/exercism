class ReverseString {
    String reverse(String inputString) {
        var builder = new StringBuilder();
        for (var i = inputString.length() - 1; i >= 0; i--) {
            builder.append(inputString.charAt(i));
        }
        return builder.toString();
    }
}
