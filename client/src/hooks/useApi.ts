// src/hooks/useApi.ts
import { useCallback, useState } from "react";
import type { CarListing } from "../models/CarListing";
import { createCarListing } from "../mocks/factories";

export interface UseApiResult<T> {
  data: T | null;
  loading: boolean;
  error: string | null;
  fetch: () => Promise<void>;
}

export const useApi = <T = CarListing[]>(options?: {
  delay?: number; // ms
  count?: number; // how many cars to generate
}): UseApiResult<T> => {
  const { delay = 700, count = 10 } = options ?? {};
  const [data, setData] = useState<T | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetch = useCallback(async () => {
    setLoading(true);
    setError(null);
    try {
      // fake network latency
      await new Promise((res) => setTimeout(res, delay));
      // create mock data
      const payload = Array.from({ length: count }, () => createCarListing());
      // cast to generic
      setData(payload as unknown as T);
    } catch (e: unknown) {
      setError(e instanceof Error ? e.message : "Unknown error");
    } finally {
      setLoading(false);
    }
  }, [delay, count]);

  return { data, loading, error, fetch };
};
