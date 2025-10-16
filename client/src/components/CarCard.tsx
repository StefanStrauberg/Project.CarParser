// src/components/CarCard.tsx
import * as React from "react";
import {
  Fade,
  Card,
  CardContent,
  Box,
  Typography,
  Chip,
  IconButton,
} from "@mui/material";
import { alpha } from "@mui/material/styles";
import { Share, LocationOn, CalendarToday } from "@mui/icons-material";
import type { CarListing } from "../models/CarListing";
import GradientChip from "./GradientChip";
// ---------------------------------------------------------------------
// 1️⃣  Types ----------------------------------------------------------
// ---------------------------------------------------------------------
export interface CarCardProps {
  car: CarListing;
}

// ---------------------------------------------------------------------
// 2️⃣  Component -------------------------------------------------------
// ---------------------------------------------------------------------
export const CarCard: React.FC<CarCardProps> = ({ car }) => (
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
      {/* --------‑  Image  --------- */}
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
        {/*  Action buttons on the image  */}
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

      {/* --------‑  Content  --------- */}
      <CardContent sx={{ p: 3 }}>
        {/* Title & price */}
        <Box sx={{ mb: 2 }}>
          <Typography
            variant="h6"
            component="h2"
            sx={{ fontWeight: 600, mb: 1, color: "#fff" }}
          >
            {car.title}
          </Typography>

          <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
            <Typography variant="h5" sx={{ fontWeight: 700, color: "#818cf8" }}>
              {car.price}
            </Typography>

            {car.price && (
              <Typography
                variant="body2"
                color="text.secondary"
                sx={{ textDecoration: "line-through" }}
              >
                {car.price}
              </Typography>
            )}
          </Box>
        </Box>

        {/* Specs */}
        <Box sx={{ display: "flex", flexWrap: "wrap", gap: 1, mb: 2 }}>
          <Chip
            label={`${car.manufactureYear} год`}
            size="small"
            variant="outlined"
            sx={{ color: "#fff", borderColor: alpha("#818cf8", 0.3) }}
          />

          <Chip
            label={car.engineDisplacement}
            size="small"
            variant="outlined"
            sx={{ color: "#fff", borderColor: alpha("#818cf8", 0.3) }}
          />

          <Chip
            label={car.transmissionType.name}
            size="small"
            variant="outlined"
            sx={{ color: "#fff", borderColor: alpha("#818cf8", 0.3) }}
          />

          <Chip
            label={car.engineType.name}
            size="small"
            variant="outlined"
            sx={{ color: "#fff", borderColor: alpha("#818cf8", 0.3) }}
          />
        </Box>

        {/* Location & date */}
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
              {car.placeRegion.name}
            </Typography>
          </Box>

          <GradientChip
            icon={<CalendarToday sx={{ fontSize: 14 }} />}
            label={car.publishDate}
            size="small"
          />
        </Box>
      </CardContent>
    </Card>
  </Fade>
);

// ---------------------------------------------------------------------
// 3️⃣  Export helpers ------------------------------------------------
// ---------------------------------------------------------------------
// If you’d like to memoise it (recommended for large lists)
export const MemoCarCard = React.memo(CarCard);

// Default export (if you prefer the “default” style)
export default CarCard;
