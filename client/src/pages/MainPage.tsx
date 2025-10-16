import { CarRental, KeyboardArrowUp, Refresh } from "@mui/icons-material";
import {
  Alert,
  alpha,
  AppBar,
  Box,
  CircularProgress,
  Container,
  CssBaseline,
  Fab,
  Fade,
  Grid,
  IconButton,
  ThemeProvider,
  Toolbar,
  Typography,
} from "@mui/material";
import { useEffect, useState } from "react";
import { darkTheme } from "../styles/darkTheme";
import GradientText from "../components/GradientText";
import ScrollTop from "../components/ScrollTop";
import { mockApi } from "../mocks/api";
import type { CarListing } from "../models/CarListing";
import CarCard from "../components/CarCard/index.tsx";

const MainPage = () => {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");
  const [lastUpdate, setLastUpdate] = useState(new Date());
  const [cars, setCars] = useState<CarListing[]>([]);

  useEffect(() => {
    loadData();
  }, []);

  useEffect(() => {
    mockApi.getCarListings(15).then(setCars);
  }, []);

  const loadData = async () => {
    try {
      setLoading(true);
      await new Promise((resolve) => setTimeout(resolve, 1500));
      setLastUpdate(new Date());
      setError("");
    } catch (err) {
      setError("Ошибка при загрузке данных");
    } finally {
      setLoading(false);
    }
  };

  const handleRefresh = async () => {
    await loadData();
  };

  const formatTime = (date) => {
    return date.toLocaleTimeString("ru-RU", {
      hour: "2-digit",
      minute: "2-digit",
    });
  };

  return (
    <ThemeProvider theme={darkTheme}>
      <CssBaseline />

      {/* Фиксированный AppBar */}
      <AppBar
        position="sticky"
        elevation={0}
        sx={{
          background: alpha("#1a1a2e", 0.9),
          backdropFilter: "blur(20px)",
          borderBottom: `1px solid ${alpha("#6366f1", 0.1)}`,
        }}
      >
        <Toolbar>
          <Box sx={{ display: "flex", alignItems: "center", gap: 2 }}>
            <Box
              sx={{
                background: "linear-gradient(45deg, #6366f1, #ec4899)",
                borderRadius: "12px",
                p: 1,
              }}
            >
              <CarRental sx={{ color: "#fff", fontSize: 28 }} />
            </Box>
            <GradientText variant="h6" sx={{ fontWeight: 700 }}>
              AutoVision
            </GradientText>
          </Box>

          <Box sx={{ flexGrow: 1 }} />

          <Box sx={{ display: "flex", alignItems: "center", gap: 2 }}>
            <Typography
              variant="body2"
              sx={{ display: { xs: "none", sm: "block" }, color: "#fff" }}
            >
              Обновлено: {formatTime(lastUpdate)}
            </Typography>
            <IconButton
              color="inherit"
              onClick={handleRefresh}
              disabled={loading}
              sx={{
                transition: "all 0.3s ease",
                "&:hover": {
                  background: "linear-gradient(45deg, #6366f1, #ec4899)",
                  transform: "rotate(45deg)",
                },
              }}
            >
              <Refresh />
            </IconButton>
          </Box>
        </Toolbar>
      </AppBar>

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
              <Grid item xs={12} sm={6} lg={4} key={car.id}>
                <CarCard car={car} />
              </Grid>
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
