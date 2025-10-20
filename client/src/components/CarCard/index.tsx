// src/components/CarCard/index.tsx
import {
  Card,
  CardContent,
  CardMedia,
  Typography,
  Box,
  Chip,
  Stack,
} from "@mui/material";
import { LocationOn, Build, Settings, CarRental } from "@mui/icons-material";
import { memo, useState } from "react";
import type { CarListing } from "../../models/CarListing";

// Импортируем стандартное изображение
import defaultCarImage from "../../assets/images/default-car.png";

export interface CarCardProps {
  car: CarListing;
  onCardClick?: (id: string) => void;
}

const CarCard: React.FC<CarCardProps> = ({ car, onCardClick }) => {
  const [imageError, setImageError] = useState(false);
  const [imageLoading, setImageLoading] = useState(true);

  // Обработчик ошибки загрузки изображения
  const handleImageError = () => {
    setImageError(true);
    setImageLoading(false);
  };

  // Обработчик успешной загрузки изображения
  const handleImageLoad = () => {
    setImageLoading(false);
  };

  // Используем стандартное изображение если произошла ошибка или изображение отсутствует
  const imageSrc = imageError || !car.image ? defaultCarImage : car.image;

  return (
    <Card
      sx={{
        width: "100%",
        height: "100%",
        maxWidth: 400,
        margin: "auto",
        borderRadius: 1.5,
        boxShadow: "0 8px 32px rgba(0, 0, 0, 0.3)",
        transition: "all 0.4s cubic-bezier(0.4, 0, 0.2, 1)",
        cursor: "pointer",
        display: "flex",
        flexDirection: "column",
        "&:hover": {
          transform: "translateY(-8px)",
          boxShadow: "0 20px 40px rgba(99, 102, 241, 0.3)",
        },
      }}
      onClick={() => onCardClick?.(car.id)}
    >
      {/* Изображение с фиксированной высотой */}
      <Box sx={{ position: "relative", flexShrink: 0 }}>
        <CardMedia
          component="img"
          height="220"
          image={imageSrc}
          alt={car.title}
          onError={handleImageError}
          onLoad={handleImageLoad}
          sx={{
            transition: "transform 0.3s ease",
            "&:hover": {
              transform: "scale(1.05)",
            },
            // Добавляем стиль для стандартного изображения
            ...((imageError || !car.image) && {
              backgroundColor: "#f5f5f5",
              objectFit: "contain",
              padding: "20px",
            }),
          }}
        />

        {/* Индикатор загрузки */}
        {imageLoading && car.image && (
          <Box
            sx={{
              position: "absolute",
              top: 0,
              left: 0,
              right: 0,
              bottom: 0,
              display: "flex",
              alignItems: "center",
              justifyContent: "center",
              backgroundColor: "rgba(0, 0, 0, 0.1)",
            }}
          >
            <Typography variant="caption" color="text.secondary">
              Загрузка...
            </Typography>
          </Box>
        )}

        {/* Бейдж с годом производства */}
        <Box
          sx={{
            position: "absolute",
            top: 12,
            right: 12,
            background: "rgba(0, 0, 0, 0.7)",
            borderRadius: "12px",
            padding: "4px 8px",
          }}
        >
          <Typography variant="caption" color="white" fontWeight="bold">
            {car.manufactureYear} год
          </Typography>
        </Box>

        {/* Бейдж для стандартного изображения */}
        {(imageError || !car.image) && (
          <Box
            sx={{
              position: "absolute",
              top: 12,
              left: 12,
              background: "rgba(99, 102, 241, 0.9)",
              borderRadius: "12px",
              padding: "4px 8px",
            }}
          >
            <Typography variant="caption" color="white" fontWeight="bold">
              Изображение отсутствует
            </Typography>
          </Box>
        )}
      </Box>

      {/* Контент с автоматическим растяжением */}
      <CardContent
        sx={{
          p: 3,
          flex: 1,
          display: "flex",
          flexDirection: "column",
        }}
      >
        {/* Заголовок с фиксированным количеством строк */}
        <Typography
          variant="h6"
          gutterBottom
          sx={{
            fontWeight: 600,
            lineHeight: 1.3,
            minHeight: "3em",
            display: "-webkit-box",
            WebkitLineClamp: 2,
            WebkitBoxOrient: "vertical",
            overflow: "hidden",
          }}
        >
          {car.title}
        </Typography>

        {/* Чипы */}
        <Stack direction="row" spacing={1} mb={2} flexWrap="wrap" gap={1}>
          <Chip
            icon={<CarRental sx={{ fontSize: 16 }} />}
            label={car.bodyType.name}
            size="small"
            variant="outlined"
            sx={{ borderColor: "#6366f1", color: "#818cf8" }}
          />
          <Chip
            icon={<Build sx={{ fontSize: 16 }} />}
            label={car.engineType.name}
            size="small"
            variant="outlined"
            sx={{ borderColor: "#ec4899", color: "#f472b6" }}
          />
          <Chip
            icon={<Settings sx={{ fontSize: 16 }} />}
            label={car.transmissionType.name}
            size="small"
            variant="outlined"
            sx={{ borderColor: "#f59e0b", color: "#fbbf24" }}
          />
        </Stack>

        {/* Описание с фиксированной высотой */}
        <Typography
          variant="body2"
          color="text.secondary"
          sx={{
            lineHeight: 1.6,
            flex: 1,
            display: "-webkit-box",
            WebkitLineClamp: 3,
            WebkitBoxOrient: "vertical",
            overflow: "hidden",
            mb: 2,
          }}
        >
          {car.description || "Описание отсутствует"}
        </Typography>

        {/* Локация */}
        <Stack direction="row" alignItems="center" spacing={1}>
          <LocationOn fontSize="small" sx={{ color: "#f472b6" }} />
          <Typography
            variant="caption"
            sx={{ color: "#818cf8", fontWeight: 500 }}
          >
            {car.placeCity.name}
          </Typography>
        </Stack>
      </CardContent>
    </Card>
  );
};

export default memo(CarCard);
