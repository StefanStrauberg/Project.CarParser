import type { BaseEntity } from "./BaseEntity";
import type { BodyType } from "./BodyType";
import type { EngineType } from "./EngineType";
import type { PlaceCity } from "./PlaceCity";
import type { PlaceRegion } from "./PlaceRegion";
import type { TransmissionType } from "./TransmissionType";

export interface CarListing extends BaseEntity {
  title: string;
  price: number;
  description?: string | null;
  url: string;
  manufactureYear: number;
  engineDisplacement: number; // decimal → number
  publishDate: Date;
  image: string;
  placeRegionId: string;
  placeRegion: PlaceRegion;
  placeCityId: string;
  placeCity: PlaceCity;
  transmissionTypeId: string;
  transmissionType: TransmissionType;
  engineTypeId: string;
  engineType: EngineType;
  bodyTypeId: string;
  bodyType: BodyType;
}
