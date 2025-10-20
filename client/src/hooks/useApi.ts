// src/hooks/useApi.ts
import type { AxiosRequestConfig, AxiosResponse } from "axios";
import axios from "axios";
import { useState, useCallback } from "react";

// Создаем экземпляр axios с базовой конфигурацией
export const apiClient = axios.create({
  baseURL: import.meta.env.REACT_APP_API_URL,
  timeout: 10000,
  headers: {
    "Content-Type": "application/json",
  },
});

// Интерфейс для состояния хука
interface UseApiResult<T> {
  data: T | null;
  loading: boolean;
  error: string;
  execute: (config?: AxiosRequestConfig) => Promise<void>;
  refetch: () => Promise<void>;
}

export const useApi = <T = unknown>(
  url: string,
  initialConfig?: AxiosRequestConfig
): UseApiResult<T> => {
  const [data, setData] = useState<T | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  const execute = useCallback(
    async (config?: AxiosRequestConfig) => {
      try {
        setLoading(true);
        setError("");

        const finalConfig = { ...initialConfig, ...config };
        const response: AxiosResponse<T> = await apiClient(url, finalConfig);

        setData(response.data);
      } catch (err) {
        let errorMessage = "Произошла ошибка";

        if (axios.isAxiosError(err)) {
          if (err.response) {
            errorMessage = `Ошибка ${err.response.status}: ${
              err.response.data?.message || "Неизвестная ошибка"
            }`;
          } else if (err.request) {
            errorMessage = "Нет соединения с сервером";
          } else {
            errorMessage = "Ошибка при настройке запроса";
          }
        }

        setError(errorMessage);
        console.error("API Error:", err);
      } finally {
        setLoading(false);
      }
    },
    [url, initialConfig]
  );

  const refetch = useCallback(async () => {
    await execute();
  }, [execute]);

  return {
    data,
    loading,
    error,
    execute,
    refetch,
  };
};
