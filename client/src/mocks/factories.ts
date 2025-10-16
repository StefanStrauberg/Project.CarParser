// src/mocks/factories.ts
import { randomDate, randomDecimal, randomInt } from "./utils";
import { v4 as uuidv4 } from "uuid";
import { faker } from "@faker-js/faker";
import type { BaseEntity } from "../models/BaseEntity";
import type { PlaceRegion } from "../models/PlaceRegion";
import type { PlaceCity } from "../models/PlaceCity";
import type { TransmissionType } from "../models/TransmissionType";
import type { EngineType } from "../models/EngineType";
import type { BodyType } from "../models/BodyType";
import type { CarListing } from "../models/CarListing";

/* ----- BaseEntity ----------------------------------------------------- */
const createBaseEntity = (): BaseEntity => ({
  id: uuidv4(),
  createdAt: randomDate(new Date(2015, 0, 1)),
  updatedAt: Math.random() < 0.3 ? randomDate() : null,
});

/* ----- Lookup entities ----------------------------------------------- */
export const createPlaceRegion = (): PlaceRegion => ({
  ...createBaseEntity(),
  name: faker.location.state(),
  number: randomInt(1, 999),
});

export const createPlaceCity = (): PlaceCity => ({
  ...createBaseEntity(),
  name: faker.location.city(),
  number: randomInt(1, 999),
});

export const createTransmissionType = (): TransmissionType => ({
  ...createBaseEntity(),
  name: faker.helpers.arrayElement([
    "Manual",
    "Automatic",
    "CVT",
    "Semi‑Automatic",
  ]),
  number: randomInt(1, 999),
});

export const createEngineType = (): EngineType => ({
  ...createBaseEntity(),
  name: faker.helpers.arrayElement(["Petrol", "Diesel", "Hybrid", "Electric"]),
  number: randomInt(1, 999),
});

export const createBodyType = (): BodyType => ({
  ...createBaseEntity(),
  name: faker.helpers.arrayElement([
    "Sedan",
    "SUV",
    "Hatchback",
    "Coupe",
    "Convertible",
  ]),
  number: randomInt(1, 999),
});

/* ----- CarListing ----------------------------------------------------- */
export const createCarListing = (): CarListing => {
  const region = createPlaceRegion();
  const city = createPlaceCity();
  const transmission = createTransmissionType();
  const engine = createEngineType();
  const body = createBodyType();

  return {
    ...createBaseEntity(),
    title: `${faker.vehicle.manufacturer()} ${faker.vehicle.model()}`,
    price: randomInt(5000, 70000),
    description: faker.lorem.sentence(),
    url: faker.internet.url(),
    manufactureYear: randomInt(1990, new Date().getFullYear()),
    engineDisplacement: randomDecimal(1.0, 6.0, 1),
    publishDate: randomDate(),
    // ids
    placeRegionId: region.id,
    placeCityId: city.id,
    transmissionTypeId: transmission.id,
    engineTypeId: engine.id,
    bodyTypeId: body.id,
    // embedded objects (could also be omitted and resolved via id in API)
    placeRegion: region,
    placeCity: city,
    transmissionType: transmission,
    engineType: engine,
    bodyType: body,
  };
};
