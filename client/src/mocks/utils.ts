// src/mocks/utils.ts

export const randomDate = (
  start: Date = new Date(2000, 0, 1),
  end: Date = new Date()
) =>
  new Date(start.getTime() + Math.random() * (end.getTime() - start.getTime()));

export const randomDecimal = (min = 0, max = 10, precision = 2) =>
  parseFloat((Math.random() * (max - min) + min).toFixed(precision));

export const randomInt = (min: number, max: number) =>
  Math.floor(Math.random() * (max - min + 1) + min);
