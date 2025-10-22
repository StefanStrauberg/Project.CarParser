// src/components/CarCard.tsx
import {
  Card,
  CardContent,
  CardMedia,
  Typography,
  Box,
  Chip,
} from "@mui/material";
import { LocalGasStation, Speed, CalendarToday } from "@mui/icons-material";
import type { CarListing } from "../../models/CarListing";
import { carCardStyles } from "../../styles/carCardStyles";

interface CarCardProps {
  car: CarListing;
}

const CarCard = ({ car }: CarCardProps) => {
  const getEngineTypeColor = (engineType: string) => {
    switch (engineType.toLowerCase()) {
      case "бензин":
        return { background: "#0066ff", color: "#fff" };
      case "дизель":
        return { background: "#ff4444", color: "#fff" };
      case "электро":
        return { background: "#00ff88", color: "#000" };
      case "гибрид":
        return { background: "#ffaa00", color: "#000" };
      default:
        return { background: "#666", color: "#fff" };
    }
  };

  const formatPrice = (price: number) => {
    return new Intl.NumberFormat("ru-RU").format(price);
  };

  const engineColor = getEngineTypeColor(car.engineType.name);

  return (
    <Card sx={carCardStyles.card}>
      <Box sx={carCardStyles.topBorder} />

      <Box sx={carCardStyles.imageWrapper}>
        <CardMedia
          className="car-image"
          component="img"
          height="200"
          image={car.image}
          alt={car.title}
          sx={carCardStyles.image}
        />

        <Box sx={carCardStyles.priceTag}>
          <Typography variant="h6" sx={carCardStyles.priceText}>
            ${formatPrice(car.price)}
          </Typography>
        </Box>

        <Chip
          label={car.engineType.name}
          size="small"
          sx={carCardStyles.engineChip(
            engineColor.background,
            engineColor.color
          )}
        />
      </Box>

      <CardContent sx={carCardStyles.content}>
        <Typography variant="h6" sx={carCardStyles.title}>
          {car.title}
        </Typography>

        <Box sx={{ mb: 2 }}>
          <Box sx={carCardStyles.specRow}>
            <LocalGasStation sx={carCardStyles.specIcon("#00aaff")} />
            <Typography variant="body2" sx={carCardStyles.specText("#00aaff")}>
              {car.engineType.name} • 2,0L
            </Typography>
          </Box>

          <Box sx={carCardStyles.specRow}>
            <Speed sx={carCardStyles.specIcon("#ff4444")} />
            <Typography variant="body2" sx={carCardStyles.specText("#ff4444")}>
              {car.transmissionType.name}
            </Typography>
          </Box>

          <Box sx={carCardStyles.specRow}>
            <CalendarToday sx={carCardStyles.specIcon("#ffaa00")} />
            <Typography variant="body2" sx={carCardStyles.specText("#ffaa00")}>
              {car.manufactureYear} • 360 000 km
            </Typography>
          </Box>
        </Box>

        <Box sx={carCardStyles.locationRow}>
          <Typography variant="caption" sx={carCardStyles.locationText}>
            {car.placeCity.name}
          </Typography>
        </Box>
      </CardContent>
    </Card>
  );
};

export default CarCard;
