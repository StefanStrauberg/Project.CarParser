// src/models/PlaceRegion.ts
import type { BaseEntity } from "./BaseEntity";

export interface PlaceRegion extends BaseEntity {
  name: string;
  number: number;
}
