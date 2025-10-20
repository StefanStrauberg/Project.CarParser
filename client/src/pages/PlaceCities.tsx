// src/pages/PlaceCities.tsx
import React from "react";
import { Container, Typography } from "@mui/material";

const PlaceCities: React.FC = () => {
  return (
    <Container sx={{ py: 4 }}>
      <Typography variant="h4" component="h1" gutterBottom>
        Place Cities
      </Typography>
      {/* Ваш контент для Place Cities */}
    </Container>
  );
};

export default PlaceCities;
