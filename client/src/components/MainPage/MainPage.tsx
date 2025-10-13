import { useState, useEffect } from "react";
import {
  Container,
  Typography,
  Card,
  CardContent,
  Grid,
  Chip,
  Box,
  CircularProgress,
  Alert,
  AppBar,
  Toolbar,
  ThemeProvider,
  createTheme,
  CssBaseline,
  IconButton,
  Fab,
  alpha,
  useScrollTrigger,
  Slide,
  Fade,
} from "@mui/material";
import {
  Refresh,
  CarRental,
  LocationOn,
  CalendarToday,
  Share,
  KeyboardArrowUp,
} from "@mui/icons-material";

// Исправленная темная тема без неверных форматов цвета
const darkTheme = createTheme({
  palette: {
    mode: "dark",
    primary: {
      main: "#6366f1",
      light: "#818cf8",
      dark: "#4338ca",
    },
    secondary: {
      main: "#ec4899",
      light: "#f472b6",
      dark: "#db2777",
    },
    background: {
      default: "#0f0f23",
      paper: "#1a1a2e",
    },
  },
  typography: {
    fontFamily: '"Inter", "Roboto", "Helvetica", "Arial", sans-serif',
    h1: {
      fontWeight: 700,
    },
    h2: {
      fontWeight: 600,
    },
    h3: {
      fontWeight: 600,
    },
  },
  components: {
    MuiCard: {
      styleOverrides: {
        root: {
          background: "linear-gradient(145deg, #1e1e3a 0%, #2d1b69 100%)",
          border: "1px solid",
          borderColor: alpha("#6366f1", 0.1),
          backdropFilter: "blur(10px)",
          borderRadius: "16px",
          position: "relative",
          overflow: "visible",
          "&::before": {
            content: '""',
            position: "absolute",
            top: 0,
            left: 0,
            right: 0,
            height: "2px",
            background: "linear-gradient(90deg, #6366f1, #ec4899)",
            borderRadius: "16px 16px 0 0",
          },
        },
      },
    },
    MuiButton: {
      styleOverrides: {
        root: {
          borderRadius: "12px",
          textTransform: "none",
          fontWeight: 600,
          transition: "all 0.3s ease",
        },
      },
    },
  },
});

// Прокрутка вверх кнопка
function ScrollTop({ children }) {
  const trigger = useScrollTrigger({
    disableHysteresis: true,
    threshold: 100,
  });

  const handleClick = (event) => {
    window.scrollTo({
      top: 0,
      behavior: "smooth",
    });
  };

  return (
    <Slide in={trigger} direction="up">
      <Box
        onClick={handleClick}
        role="presentation"
        sx={{ position: "fixed", bottom: 24, right: 24 }}
      >
        {children}
      </Box>
    </Slide>
  );
}

// Моковые данные с улучшенной структурой
const mockCars = [
  {
    id: 1,
    title: "Toyota Camry 2023 Hybrid",
    price: "$25,800",
    originalPrice: "$27,000",
    location: "Москва, Центр",
    date: "2 часа назад",
    image:
      "https://images.unsplash.com/photo-1621135802920-133df287f89c?w=400&h=250&fit=crop",
    isNew: true,
    isTrending: true,
    mileage: "5,000 км",
    transmission: "Автомат",
    fuel: "Гибрид",
    year: 2023,
    rating: 4.8,
  },
  {
    id: 2,
    title: "BMW X5 xDrive40i",
    price: "$65,500",
    originalPrice: "$68,000",
    location: "Санкт-Петербург",
    date: "1 час назад",
    image:
      "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=400&h=250&fit=crop",
    isNew: true,
    isTrending: true,
    mileage: "2,500 км",
    transmission: "Автомат",
    fuel: "Бензин",
    year: 2023,
    rating: 4.9,
  },
  {
    id: 3,
    title: "Mercedes-Benz E-Class",
    price: "$58,900",
    originalPrice: "$61,200",
    location: "Казань",
    date: "3 часа назад",
    image:
      "https://images.unsplash.com/photo-1563720223480-8d83badec9a1?w=400&h=250&fit=crop",
    isNew: true,
    isTrending: false,
    mileage: "8,000 км",
    transmission: "Автомат",
    fuel: "Дизель",
    year: 2023,
    rating: 4.7,
  },
  {
    id: 4,
    title: "Audi Q7 Premium",
    price: "$72,300",
    originalPrice: "$75,000",
    location: "Москва, Новая Москва",
    date: "30 минут назад",
    image:
      "https://images.unsplash.com/photo-1503376780353-7e6692767b70?w=400&h=250&fit=crop",
    isNew: true,
    isTrending: true,
    mileage: "1,200 км",
    transmission: "Автомат",
    fuel: "Бензин",
    year: 2023,
    rating: 4.8,
  },
  {
    id: 5,
    title: "Hyundai Tucson Hybrid",
    price: "$32,500",
    originalPrice: "$34,000",
    location: "Екатеринбург",
    date: "4 часа назад",
    image:
      "https://images.unsplash.com/photo-1621135802920-133df287f89c?w=400&h=250&fit=crop",
    isNew: true,
    isTrending: false,
    mileage: "3,800 км",
    transmission: "Автомат",
    fuel: "Гибрид",
    year: 2023,
    rating: 4.6,
  },
  {
    id: 6,
    title: "Porsche 911 Carrera",
    price: "$125,000",
    originalPrice: "$130,000",
    location: "Москва, Рублевка",
    date: "15 минут назад",
    image:
      "https://images.unsplash.com/photo-1503376780353-7e6692767b70?w=400&h=250&fit=crop",
    isNew: true,
    isTrending: true,
    mileage: "500 км",
    transmission: "Автомат",
    fuel: "Бензин",
    year: 2023,
    rating: 5.0,
  },
];

// Градиентный текст компонент
const GradientText = ({ children, variant = "h1", ...props }) => (
  <Typography
    variant={variant}
    {...props}
    sx={{
      background: "linear-gradient(45deg, #818cf8 30%, #f472b6 90%)",
      backgroundClip: "text",
      WebkitBackgroundClip: "text",
      WebkitTextFillColor: "transparent",
      ...props.sx,
    }}
  >
    {children}
  </Typography>
);

// Градиентный чип компонент
const GradientChip = ({ label, ...props }) => (
  <Chip
    label={label}
    {...props}
    sx={{
      background: "linear-gradient(45deg, #6366f1, #818cf8)",
      color: "#fff",
      fontWeight: 600,
      ...props.sx,
    }}
  />
);

const MainPage = () => {
  const [cars, setCars] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");
  const [lastUpdate, setLastUpdate] = useState(new Date());

  useEffect(() => {
    loadData();
  }, []);

  const loadData = async () => {
    try {
      setLoading(true);
      await new Promise((resolve) => setTimeout(resolve, 1500));
      setCars(mockCars);
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

  const CarCard = ({ car }) => (
    <Fade in timeout={800}>
      <Card
        sx={{
          height: "100%",
          transition: "all 0.3s ease",
          "&:hover": {
            transform: "translateY(-8px)",
            boxShadow: `0 20px 40px ${alpha("#6366f1", 0.2)}`,
          },
        }}
      >
        {/* Изображение */}
        <Box sx={{ position: "relative" }}>
          <Box
            component="img"
            src={car.image}
            alt={car.title}
            sx={{
              width: "100%",
              height: 200,
              objectFit: "cover",
              borderTopLeftRadius: "16px",
              borderTopRightRadius: "16px",
            }}
          />

          {/* Кнопки действий на изображении */}
          <Box
            sx={{
              position: "absolute",
              top: 12,
              right: 12,
              display: "flex",
              gap: 1,
            }}
          >
            <IconButton
              size="small"
              sx={{
                backgroundColor: alpha("#000", 0.6),
                backdropFilter: "blur(10px)",
                "&:hover": { backgroundColor: alpha("#000", 0.8) },
              }}
            >
              <Share sx={{ fontSize: 18 }} />
            </IconButton>
          </Box>
        </Box>

        <CardContent sx={{ p: 3 }}>
          {/* Заголовок и цена */}
          <Box sx={{ mb: 2 }}>
            <Typography
              variant="h6"
              component="h2"
              sx={{ fontWeight: 600, mb: 1, color: "#fff" }}
            >
              {car.title}
            </Typography>
            <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
              <Typography
                variant="h5"
                sx={{ fontWeight: 700, color: "#818cf8" }}
              >
                {car.price}
              </Typography>
              <Typography
                variant="body2"
                color="text.secondary"
                sx={{ textDecoration: "line-through" }}
              >
                {car.originalPrice}
              </Typography>
            </Box>
          </Box>

          {/* Характеристики */}
          <Box sx={{ display: "flex", flexWrap: "wrap", gap: 1, mb: 2 }}>
            <Chip
              label={`${car.year} год`}
              size="small"
              variant="outlined"
              sx={{ color: "#fff", borderColor: alpha("#818cf8", 0.3) }}
            />
            <Chip
              label={car.mileage}
              size="small"
              variant="outlined"
              sx={{ color: "#fff", borderColor: alpha("#818cf8", 0.3) }}
            />
            <Chip
              label={car.transmission}
              size="small"
              variant="outlined"
              sx={{ color: "#fff", borderColor: alpha("#818cf8", 0.3) }}
            />
            <Chip
              label={car.fuel}
              size="small"
              variant="outlined"
              sx={{ color: "#fff", borderColor: alpha("#818cf8", 0.3) }}
            />
          </Box>

          {/* Локация и дата */}
          <Box
            sx={{
              display: "flex",
              justifyContent: "space-between",
              alignItems: "center",
            }}
          >
            <Box sx={{ display: "flex", alignItems: "center", gap: 0.5 }}>
              <LocationOn sx={{ fontSize: 16, color: "#818cf8" }} />
              <Typography variant="body2" color="text.secondary">
                {car.location}
              </Typography>
            </Box>
            <GradientChip
              icon={<CalendarToday sx={{ fontSize: 14 }} />}
              label={car.date}
              size="small"
            />
          </Box>
        </CardContent>
      </Card>
    </Fade>
  );

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
                  {mockCars.length}+
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
