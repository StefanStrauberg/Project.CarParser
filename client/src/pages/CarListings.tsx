// src/pages/CarListings.tsx
import React from "react";
import { Container, Typography } from "@mui/material";

const CarListings: React.FC = () => {
  return (
    <Container sx={{ py: 4 }}>
      <Typography variant="h4" component="h1" gutterBottom>
        Car Listings
      </Typography>
      {/* Ваш контент для Car Listings */}
    </Container>
  );
};

export default CarListings;
