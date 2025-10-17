// src/pages/MainPage.tsx
import { KeyboardArrowUp } from "@mui/icons-material";
import {
  Alert,
  alpha,
  Box,
  CircularProgress,
  Container,
  CssBaseline,
  Fab,
  Fade,
  Grid,
  ThemeProvider,
  Typography,
} from "@mui/material";
import { useEffect, useState } from "react";
import { darkTheme } from "../styles/darkTheme";
import GradientText from "../components/GradientText";
import ScrollTop from "../components/ScrollTop";
import { mockApi } from "../mocks/api";
import type { CarListing } from "../models/CarListing";
import CarCard from "../components/CarCard";
import AppHeader from "../components/AppBar";

const MainPage = () => {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");
  const [lastUpdate, setLastUpdate] = useState(new Date());
  const [cars, setCars] = useState<CarListing[]>([]);

  useEffect(() => {
    loadData();
  }, []);

  const loadData = async () => {
    try {
      setLoading(true);
      setError("");
      // Загружаем данные параллельно
      const [carsData] = await Promise.all([
        mockApi.getCarListings(15),
        new Promise((resolve) => setTimeout(resolve, 1500)), // Имитация загрузки
      ]);
      setCars(carsData);
      setLastUpdate(new Date());
    } catch (err) {
      setError("Ошибка при загрузке данных");
      console.error("Error loading data:", err);
    } finally {
      setLoading(false);
    }
  };

  const handleRefresh = async () => {
    await loadData();
  };

  const formatTime = (date: Date) => {
    return date.toLocaleTimeString("ru-RU", {
      hour: "2-digit",
      minute: "2-digit",
    });
  };

  return (
    <ThemeProvider theme={darkTheme}>
      <CssBaseline />
      {/* Фиксированный AppBar */}
      <AppHeader
        lastUpdate={lastUpdate}
        loading={loading}
        onRefresh={handleRefresh}
        formatTime={formatTime}
      />

      <Container maxWidth="xl" sx={{ py: 4 }}>
        {/* Герой секция */}
        <Box textAlign="center" mb={6}>
          <Fade in timeout={1000}>
            <Box>
              <GradientText
                variant="h1"
                gutterBottom
                sx={{ mb: 2, fontSize: { xs: "2.5rem", md: "3.5rem" } }}
              >
                Новые автомобили сегодня
              </GradientText>
            </Box>
          </Fade>
          <Fade in timeout={1200}>
            <Typography variant="h5" color="text.secondary" sx={{ mb: 4 }}>
              Самые свежие предложения на рынке • Обновляется в реальном времени
            </Typography>
          </Fade>

          {/* Статистика */}
          <Fade in timeout={1400}>
            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                gap: 4,
                flexWrap: "wrap",
              }}
            >
              <Box textAlign="center">
                <Typography
                  variant="h4"
                  sx={{ fontWeight: 700, color: "#818cf8" }}
                >
                  {cars.length}+
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  новых авто
                </Typography>
              </Box>
              <Box textAlign="center">
                <Typography
                  variant="h4"
                  sx={{ fontWeight: 700, color: "#f472b6" }}
                >
                  24/7
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  мониторинг
                </Typography>
              </Box>
              <Box textAlign="center">
                <Typography
                  variant="h4"
                  sx={{ fontWeight: 700, color: "#818cf8" }}
                >
                  {formatTime(lastUpdate)}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  последнее обновление
                </Typography>
              </Box>
            </Box>
          </Fade>
        </Box>

        {/* Статус */}
        {error && (
          <Alert
            severity="error"
            sx={{
              mb: 3,
              borderRadius: "12px",
              background: alpha("#f44336", 0.1),
            }}
          >
            {error}
          </Alert>
        )}

        {/* Список автомобилей */}
        {loading ? (
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
        ) : (
          <Grid container spacing={3}>
            {cars.map((car) => (
              <Box
                key={car.id}
                sx={{ width: { xs: "100%", sm: "50%", md: "33.333%" }, p: 1 }}
              >
                <CarCard car={car} />
              </Box>
            ))}
          </Grid>
        )}

        {/* Сообщение если нет автомобилей */}
        {!loading && cars.length === 0 && (
          <Box textAlign="center" py={8}>
            <Typography variant="h6" color="text.secondary">
              На сегодня новых объявлений не найдено
            </Typography>
          </Box>
        )}

        {/* Плавающая кнопка обновления */}
        <ScrollTop>
          <Fab
            size="medium"
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
      </Container>
    </ThemeProvider>
  );
};

export default MainPage;
