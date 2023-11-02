// @ts-check

const LICENSED_VEHICLES = ['car', 'truck']

/**
 * Determines whether or not you need a license to operate a certain kind of vehicle.
 *
 * @param {string} kind
 * @returns {boolean} whether a license is required
 */
export function needsLicense(kind) {
  return LICENSED_VEHICLES.includes(kind);
}

/**
 * Helps choosing between two options by recommending the one that
 * comes first in dictionary order.
 *
 * @param {string} option1
 * @param {string} option2
 * @returns {string} a sentence of advice which option to choose
 */
export function chooseVehicle(option1, option2) {
  const choice = [option1, option2].sort()[0];
  return `${choice} is clearly the better choice.`;
}

/**
 * Calculates an estimate for the price of a used vehicle in the dealership
 * based on the original price and the age of the vehicle.
 *
 * @param {number} originalPrice
 * @param {number} age
 * @returns {number} expected resell price in the dealership
 */
export function calculateResellPrice(originalPrice, age) {
  return calculateResellPercentage(age) * originalPrice;
}

/**
 * Calculates the estimated resell percentage based on the age of a vehicle.
 * @param {number} age
 * @returns {number} the resell percentage as a number between 0 and 1
 */
function calculateResellPercentage(age) {
  if (age > 10) {
    return 0.5;
  }

  if (age >= 3) {
    return 0.7;
  }

  return 0.8;
}
