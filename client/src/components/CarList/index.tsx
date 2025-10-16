// src/components/CarList/index.tsx
import { Grid, CircularProgress, Alert } from "@mui/material";
import { useApi } from "../../hooks/useApi";
import CarCard from "../CarCard";
import ScrollTop from "../ScrollTop";
import React from "react";
import type { CarListing } from "../../models/CarListing";

export const CarList: React.FC = () => {
  const { data, loading, error, fetch } = useApi<CarListing[]>();

  // load on mount
  React.useEffect(() => {
    fetch();
  }, [fetch]);

  return (
    <>
      {loading && <CircularProgress sx={{ display: "block", m: "auto" }} />}

      {error && <Alert severity="error">{error}</Alert>}

      {data && (
        <Grid container spacing={2} sx={{ p: 2 }}>
          {data.map((car) => (
            <Grid item xs={12} sm={6} md={4} key={car.id}>
              <CarCard car={car} />
            </Grid>
          ))}
        </Grid>
      )}

      <ScrollTop>
        <FloatingActionButton color="primary" aria-label="scroll back to top">
          <ArrowUpwardIcon />
        </FloatingActionButton>
      </ScrollTop>
    </>
  );
};
