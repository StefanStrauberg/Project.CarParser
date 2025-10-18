// src/models/BodyType.ts
import type { BaseEntity } from "./BaseEntity";

export interface BodyType extends BaseEntity {
  name: string;
  number: number;
}
