// src/hooks/useCarListings.ts
import { useState, useEffect, useCallback } from "react";
import axios from "axios";
import type { CarListing } from "../models/CarListing";

// Создаем экземпляр axios с базовой конфигурацией
const apiClient = axios.create({
  baseURL: import.meta.env.REACT_APP_API_URL,
  timeout: 10000,
  headers: {
    "Content-Type": "application/json",
  },
});

// Интерфейс для состояния хука
interface UseCarListingsResult {
  cars: CarListing[];
  loading: boolean;
  error: string;
  lastUpdate: Date;
  loadData: () => Promise<void>;
  refetch: () => Promise<void>;
}

export const useCarListings = (limit?: number): UseCarListingsResult => {
  const [cars, setCars] = useState<CarListing[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");
  const [lastUpdate, setLastUpdate] = useState(new Date());

  // Функция для загрузки данных
  const loadData = useCallback(async () => {
    try {
      setLoading(true);
      setError("");

      // Используем axios вместо mockApi
      const response = await apiClient.get<CarListing[]>(
        "/api/CarListings/GetCarListingsByFilter",
        {
          params: { limit: limit || 15 },
        }
      );

      // Имитируем задержку для демонстрации (в реальном приложении убрать)
      await new Promise((resolve) => setTimeout(resolve, 1500));

      setCars(response.data);
      setLastUpdate(new Date());
    } catch (err) {
      let errorMessage = "Ошибка при загрузке данных";

      if (axios.isAxiosError(err)) {
        if (err.response) {
          // Сервер ответил с ошибкой
          errorMessage = `Ошибка сервера: ${err.response.status}`;
        } else if (err.request) {
          // Запрос был сделан, но ответ не получен
          errorMessage = "Нет соединения с сервером";
        } else {
          // Что-то пошло не так при настройке запроса
          errorMessage = "Ошибка при настройке запроса";
        }
      }

      setError(errorMessage);
      console.error("Error loading car listings:", err);
    } finally {
      setLoading(false);
    }
  }, [limit]);

  // Функция для принудительного обновления
  const refetch = useCallback(async () => {
    await loadData();
  }, [loadData]);

  // Загружаем данные при монтировании
  useEffect(() => {
    loadData();
  }, [loadData]);

  return {
    cars,
    loading,
    error,
    lastUpdate,
    loadData,
    refetch,
  };
};
