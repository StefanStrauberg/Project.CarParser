// src/mocks/api.ts
import type { CarListing } from "../models/CarListing";
import { createCarListing } from "./factories";

export const mockApi = {
  async getCarListings(count = 10): Promise<CarListing[]> {
    return Array.from({ length: count }, () => createCarListing());
  },

  async getCarListingById(id: string): Promise<CarListing | undefined> {
    // For a mock we can generate a bunch of items and search the array
    const all = await this.getCarListings(50); // generate a pool
    return all.find((c) => c.id === id);
  },

  async searchCarListings(query: string): Promise<CarListing[]> {
    const all = await this.getCarListings(50);
    return all.filter((c) =>
      c.title.toLowerCase().includes(query.toLowerCase())
    );
  },
};
