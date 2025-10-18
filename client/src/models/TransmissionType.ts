// src/models/TransmissionType.ts
import type { BaseEntity } from "./BaseEntity";

export interface TransmissionType extends BaseEntity {
  name: string;
  number: number;
}
