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
import {
  Favorite,
  Share,
  Comment,
  LocationOn,
  Build,
  Settings,
  CarRental,
} from "@mui/icons-material";
import { memo } from "react";
import type { CarListing } from "../../models/CarListing";

export interface CarCardProps {
  /** The car item to display */
  car: CarListing;
  /** Callback that receives the car id when the card is clicked */
  onCardClick?: (id: string) => void;
}

const CarCard: React.FC<CarCardProps> = ({ car, onCardClick }) => (
  <Card
    sx={{
      maxWidth: 360,
      margin: "auto",
      borderRadius: 2,
      boxShadow: 3,
      transition: "transform 0.2s",
      "&:hover": { transform: "translateY(-4px)" },
    }}
    onClick={() => onCardClick?.(car.id)}
  >
    <CardMedia component="img" height="200" image={car.image} alt={car.title} />

    <CardContent>
      <Typography variant="h6" gutterBottom>
        {car.title}
      </Typography>

      <Stack direction="row" spacing={1} mb={1}>
        <Chip icon={<CarRental />} label={car.bodyType.name} size="small" />
        <Chip icon={<Build />} label={car.engineType.name} size="small" />
        <Chip
          icon={<Settings />}
          label={car.transmissionType.name}
          size="small"
        />
      </Stack>

      <Typography variant="body2" color="text.secondary" paragraph>
        {car.description}
      </Typography>

      <Stack direction="row" alignItems="center" spacing={1}>
        <LocationOn fontSize="small" />
        <Typography variant="caption">{car.placeCity.name}</Typography>
      </Stack>

      <Box sx={{ display: "flex", justifyContent: "space-between", mt: 2 }}>
        <Typography variant="subtitle1" fontWeight="bold">
          ${car.price.toLocaleString()}
        </Typography>

        <Stack direction="row" spacing={0.5}>
          <Favorite color="error" fontSize="small" />
          <Comment fontSize="small" />
          <Share fontSize="small" />
        </Stack>
      </Box>
    </CardContent>
  </Card>
);

// Memoise – the component is pure (no side‑effects)
export default memo(CarCard);
