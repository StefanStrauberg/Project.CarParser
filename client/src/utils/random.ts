// src/utils/random.ts
export const randomDate = (
  start = new Date(2000, 0, 1),
  end = new Date()
): Date =>
  new Date(start.getTime() + Math.random() * (end.getTime() - start.getTime()));

export const randomInt = (min: number, max: number): number =>
  Math.floor(Math.random() * (max - min + 1) + min);

export const randomDecimal = (min = 0, max = 10, precision = 2): number =>
  parseFloat((Math.random() * (max - min) + min).toFixed(precision));
