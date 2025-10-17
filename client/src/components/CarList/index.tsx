// src/components/CarList/index.tsx
import {
  Grid,
  CircularProgress,
  Alert,
  Fab,
  Box,
  Typography,
} from "@mui/material";
import { KeyboardArrowUp } from "@mui/icons-material";
import { useApi } from "../../hooks/useApi";
import CarCard from "../CarCard";
import ScrollTop from "../ScrollTop";
import React from "react";
import type { CarListing } from "../../models/CarListing";

export const CarList: React.FC = () => {
  const { data, loading, error, fetch } = useApi<CarListing[]>({
    delay: 700,
    count: 15,
  });

  React.useEffect(() => {
    fetch();
  }, [fetch]);

  // Если данные загружаются впервые
  if (loading && !data) {
    return (
      <Box
        display="flex"
        justifyContent="center"
        alignItems="center"
        minHeight="400px"
      >
        <Box textAlign="center">
          <CircularProgress
            size={60}
            thickness={4}
            sx={{
              color: "primary.main",
              mb: 2,
            }}
          />
          <Typography variant="h6" color="text.secondary">
            Ищем лучшие предложения...
          </Typography>
        </Box>
      </Box>
    );
  }

  return (
    <>
      {error && (
        <Alert
          severity="error"
          sx={{
            mb: 3,
            borderRadius: "12px",
          }}
        >
          {error}
        </Alert>
      )}

      {data && data.length > 0 && (
        <Grid container spacing={3}>
          {data.map((car) => (
            <Box
              key={car.id}
              sx={{ width: { xs: "100%", sm: "50%", md: "33.333%" }, p: 1 }}
            >
              <CarCard car={car} />
            </Box>
          ))}
        </Grid>
      )}

      {/* Сообщение если нет данных после загрузки */}
      {!loading && data && data.length === 0 && (
        <Box textAlign="center" py={8}>
          <Typography variant="h6" color="text.secondary">
            На сегодня новых объявлений не найдено
          </Typography>
        </Box>
      )}

      {/* Показываем спиннер поверх данных при повторной загрузке */}
      {loading && data && (
        <Box display="flex" justifyContent="center" py={2}>
          <CircularProgress />
        </Box>
      )}

      <ScrollTop>
        <Fab
          color="primary"
          aria-label="scroll back to top"
          sx={{
            background: "linear-gradient(45deg, #6366f1, #ec4899)",
            color: "white",
            "&:hover": {
              background: "linear-gradient(45deg, #575bc7, #db2777)",
            },
          }}
        >
          <KeyboardArrowUp />
        </Fab>
      </ScrollTop>
    </>
  );
};
