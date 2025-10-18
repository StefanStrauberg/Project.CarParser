import {
  Card,
  CardContent,
  CardMedia,
  Typography,
  Box,
  Chip,
  Stack,
  IconButton,
  Rating,
} from "@mui/material";
import {
  Favorite,
  Share,
  Comment,
  LocationOn,
  Build,
  Settings,
  CarRental,
} from "@mui/icons-material";
import { memo, useState } from "react";
import type { CarListing } from "../../models/CarListing";

export interface CarCardProps {
  car: CarListing;
  onCardClick?: (id: string) => void;
}

const CarCard: React.FC<CarCardProps> = ({ car, onCardClick }) => {
  const [isFavorite, setIsFavorite] = useState(false);

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
          image={car.image}
          alt={car.title}
          sx={{
            transition: "transform 0.3s ease",
            "&:hover": {
              transform: "scale(1.05)",
            },
          }}
        />
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
        <Stack direction="row" alignItems="center" spacing={1} mb={2}>
          <LocationOn fontSize="small" sx={{ color: "#f472b6" }} />
          <Typography
            variant="caption"
            sx={{ color: "#818cf8", fontWeight: 500 }}
          >
            {car.placeCity.name}
          </Typography>
        </Stack>

        {/* Цена и действия */}
        <Box
          sx={{
            display: "flex",
            justifyContent: "space-between",
            alignItems: "center",
            mt: "auto",
            flexShrink: 0,
          }}
        >
          <Box>
            <Typography variant="h6" fontWeight="800" sx={{ color: "#f59e0b" }}>
              ${car.price.toLocaleString()}
            </Typography>
            <Rating value={4.5} readOnly size="small" precision={0.5} />
          </Box>

          <Stack direction="row" spacing={0.5}>
            <IconButton
              size="small"
              onClick={(e) => {
                e.stopPropagation();
                setIsFavorite(!isFavorite);
              }}
              sx={{
                color: isFavorite ? "#ec4899" : "text.secondary",
                transition: "all 0.3s ease",
                "&:hover": {
                  color: "#ec4899",
                  transform: "scale(1.2)",
                },
              }}
            >
              <Favorite fontSize="small" />
            </IconButton>
            <IconButton
              size="small"
              sx={{
                transition: "all 0.3s ease",
                "&:hover": {
                  color: "#6366f1",
                  transform: "scale(1.2)",
                },
              }}
            >
              <Comment fontSize="small" />
            </IconButton>
            <IconButton
              size="small"
              sx={{
                transition: "all 0.3s ease",
                "&:hover": {
                  color: "#f59e0b",
                  transform: "scale(1.2)",
                },
              }}
            >
              <Share fontSize="small" />
            </IconButton>
          </Stack>
        </Box>
      </CardContent>
    </Card>
  );
};

export default memo(CarCard);
