// src/mocks/factories.ts
import { faker } from "@faker-js/faker";
import { randomDate, randomDecimal, randomInt } from "../utils/random";
import type { BaseEntity } from "../models/BaseEntity";
import type { BodyType } from "../models/BodyType";
import type { EngineType } from "../models/EngineType";
import type { TransmissionType } from "../models/TransmissionType";
import type { PlaceRegion } from "../models/PlaceRegion";
import type { PlaceCity } from "../models/PlaceCity";
import type { CarListing } from "../models/CarListing";

const base = (): BaseEntity => ({
  id: faker.string.uuid(),
  createdAt: randomDate(new Date(2000, 0, 1), new Date()),
  updatedAt: randomDate(),
});

export const createBodyType = (): BodyType => ({
  ...base(),
  name: faker.helpers.arrayElement([
    "Sedan",
    "SUV",
    "Hatchback",
    "Coupe",
    "Convertible",
  ]),
  number: randomInt(1, 999),
});

export const createEngineType = (): EngineType => ({
  ...base(),
  name: faker.helpers.arrayElement(["Petrol", "Diesel", "Hybrid", "Electric"]),
  number: randomInt(1, 999),
});

export const createTransmissionType = (): TransmissionType => ({
  ...base(),
  name: faker.helpers.arrayElement([
    "Manual",
    "Automatic",
    "CVT",
    "Semi‑Automatic",
  ]),
  number: randomInt(1, 999),
});

export const createPlaceRegion = (): PlaceRegion => ({
  ...base(),
  name: faker.location.state(),
  number: randomInt(1, 999),
});

export const createPlaceCity = (): PlaceCity => ({
  ...base(),
  name: faker.location.city(),
  number: randomInt(1, 999),
});

export const createCarListing = (): CarListing => {
  const region = createPlaceRegion();
  const city = createPlaceCity();
  const transmission = createTransmissionType();
  const engine = createEngineType();
  const body = createBodyType();

  const listing: CarListing = {
    ...base(),
    title: `${faker.vehicle.manufacturer()} ${faker.vehicle.model()}`,
    price: randomInt(5_000, 70_000),
    description: faker.lorem.sentence(),
    url: faker.internet.url(),
    manufactureYear: randomInt(1990, new Date().getFullYear()),
    engineDisplacement: randomDecimal(1.0, 6.0, 1),
    publishDate: randomDate(),
    // image: faker.image.urlLoremFlickr({ category: "car" }),
    image: `https://picsum.photos/400/300?random=${faker.number.int({
      min: 1,
      max: 1000,
    })}`,
    placeRegionId: region.id,
    placeCityId: city.id,
    transmissionTypeId: transmission.id,
    engineTypeId: engine.id,
    bodyTypeId: body.id,
    placeRegion: region,
    placeCity: city,
    transmissionType: transmission,
    engineType: engine,
    bodyType: body,
  };

  return listing;
};
