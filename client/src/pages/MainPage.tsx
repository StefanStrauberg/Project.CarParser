// src/pages/MainPage.tsx
import { KeyboardArrowUp } from "@mui/icons-material";
import {
  Alert,
  alpha,
  Box,
  CircularProgress,
  Container,
  Fab,
  Fade,
  Typography,
  Zoom,
} from "@mui/material";
import GradientText from "../components/GradientText";
import ScrollTop from "../components/ScrollTop";
import CarCard from "../components/CarCard";
import { useCarListings } from "../hooks/useCarListings"; // Импортируем наш хук

const MainPage = () => {
  // Используем кастомный хук
  const { cars, loading, error, lastUpdate, refetch } = useCarListings(15);

  const formatTime = (date: Date) => {
    return date.toLocaleTimeString("ru-RU", {
      hour: "2-digit",
      minute: "2-digit",
    });
  };

  return (
    <Container maxWidth="xl" sx={{ py: 4, position: "relative" }}>
      <Box textAlign="center" mb={8} sx={{ position: "relative" }}>
        <Fade in timeout={800}>
          <Box>
            <GradientText
              variant="h1"
              gutterBottom
              sx={{
                mb: 3,
                fontSize: { xs: "2.5rem", md: "4rem" },
                textShadow: "0 4px 20px rgba(99, 102, 241, 0.3)",
              }}
            >
              Новые автомобили
              <Box
                component="span"
                sx={{ display: "block", fontSize: "0.6em" }}
              >
                сегодня
              </Box>
            </GradientText>
          </Box>
        </Fade>

        <Fade in timeout={1000}>
          <Typography
            variant="h5"
            color="text.secondary"
            sx={{
              mb: 6,
              background: "linear-gradient(45deg, #818cf8, #f472b6, #f59e0b)",
              backgroundClip: "text",
              WebkitBackgroundClip: "text",
              WebkitTextFillColor: "transparent",
              fontWeight: 500,
            }}
          >
            Самые свежие предложения на рынке • Постоянные обновления
          </Typography>
        </Fade>

        {/* Статистика */}
        <Fade in timeout={1200}>
          <Box
            sx={{
              display: "flex",
              justifyContent: "center",
              gap: 6,
              flexWrap: "wrap",
            }}
          >
            {[
              {
                value: `${cars.length}+`,
                label: "новых авто",
                color: "#818cf8",
              },
              { value: "24/7", label: "мониторинг", color: "#f472b6" },
              {
                value: formatTime(lastUpdate),
                label: "последнее обновление",
                color: "#f59e0b",
              },
            ].map((item, index) => (
              <Zoom in timeout={1400 + index * 200} key={item.label}>
                <Box
                  textAlign="center"
                  sx={{
                    p: 3,
                    background: "rgba(30, 30, 58, 0.6)",
                    borderRadius: "20px",
                    border: "1px solid",
                    borderColor: alpha(item.color, 0.2),
                    backdropFilter: "blur(10px)",
                    minWidth: 140,
                  }}
                >
                  <Typography
                    variant="h4"
                    sx={{
                      fontWeight: 800,
                      color: item.color,
                      textShadow: `0 2px 10px ${alpha(item.color, 0.3)}`,
                    }}
                  >
                    {item.value}
                  </Typography>
                  <Typography
                    variant="body2"
                    color="text.secondary"
                    sx={{ mt: 1 }}
                  >
                    {item.label}
                  </Typography>
                </Box>
              </Zoom>
            ))}
          </Box>
        </Fade>
      </Box>

      {/* Статус */}
      {error && (
        <Fade in>
          <Alert
            severity="error"
            sx={{
              mb: 3,
              borderRadius: "16px",
              background: alpha("#f44336", 0.1),
              border: "1px solid",
              borderColor: alpha("#f44336", 0.2),
              backdropFilter: "blur(10px)",
            }}
            action={
              <button
                onClick={refetch}
                style={{
                  background: "none",
                  border: "none",
                  color: "#f44336",
                  cursor: "pointer",
                  textDecoration: "underline",
                }}
              >
                Повторить
              </button>
            }
          >
            {error}
          </Alert>
        </Fade>
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
              size={80}
              thickness={4}
              sx={{
                color: "primary.main",
                mb: 3,
                background: "linear-gradient(45deg, #6366f1, #ec4899)",
                borderRadius: "50%",
                padding: "8px",
              }}
            />
            <Typography
              variant="h6"
              color="text.secondary"
              sx={{
                background: "linear-gradient(45deg, #818cf8, #f472b6)",
                backgroundClip: "text",
                WebkitBackgroundClip: "text",
                WebkitTextFillColor: "transparent",
              }}
            >
              Ищем лучшие предложения...
            </Typography>
          </Box>
        </Box>
      ) : (
        <Box
          sx={{
            display: "flex",
            flexWrap: "wrap",
            gap: 3,
            justifyContent: "center",
            mx: { xs: 0, sm: -1.5 },
          }}
        >
          {cars.map((car, index) => (
            <Box
              key={car.id}
              sx={{
                width: {
                  xs: "100%",
                  sm: "calc(50% - 12px)",
                  md: "calc(33.333% - 16px)",
                },
                display: "flex",
                justifyContent: "center",
              }}
            >
              <Fade in timeout={800 + index * 100}>
                <Box sx={{ width: "100%", maxWidth: 400 }}>
                  <CarCard car={car} />
                </Box>
              </Fade>
            </Box>
          ))}
        </Box>
      )}

      {/* Сообщение если нет автомобилей */}
      {!loading && cars.length === 0 && (
        <Fade in>
          <Box textAlign="center" py={8}>
            <Typography
              variant="h6"
              color="text.secondary"
              sx={{
                background: "linear-gradient(45deg, #818cf8, #f472b6)",
                backgroundClip: "text",
                WebkitBackgroundClip: "text",
                WebkitTextFillColor: "transparent",
              }}
            >
              На сегодня новых объявлений не найдено
            </Typography>
          </Box>
        </Fade>
      )}

      {/* Плавающая кнопка обновления */}
      <ScrollTop>
        <Fab
          size="medium"
          sx={{
            background: "linear-gradient(45deg, #6366f1, #ec4899, #f59e0b)",
            color: "white",
            "&:hover": {
              background: "linear-gradient(45deg, #575bc7, #db2777, #eab308)",
              transform: "scale(1.1)",
            },
            transition: "all 0.3s ease",
            boxShadow: "0 8px 25px rgba(99, 102, 241, 0.4)",
          }}
        >
          <KeyboardArrowUp />
        </Fab>
      </ScrollTop>
    </Container>
  );
};

export default MainPage;
