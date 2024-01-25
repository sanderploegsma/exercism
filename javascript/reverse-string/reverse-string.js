//
// This is only a SKELETON file for the 'Reverse String' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const reverseString = s => s
  .split('')
  .map((_, i) => s[s.length - i - 1])
  .join('');
