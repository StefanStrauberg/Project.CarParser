// src/components/CarList/index.tsx
import {
  Grid,
  CircularProgress,
  Alert,
  Fab,
  Box,
  Typography,
  Fade,
} from "@mui/material";
import { KeyboardArrowUp, MilitaryTech } from "@mui/icons-material";
import CarCard from "../CarCard";
import ScrollTop from "../ScrollTop";
import { useCarListings } from "../../hooks/useCarListings";
import { carListStyles } from "../../styles/carListStyles";

export const CarList: React.FC = () => {
  const { cars, loading, error, refetch } = useCarListings(15);

  if (loading && cars.length === 0) {
    return (
      <Box sx={carListStyles.loadingWrapper}>
        <Box textAlign="center">
          <CircularProgress
            size={60}
            thickness={4}
            sx={carListStyles.loadingCircle}
          />
          <Typography variant="h6" sx={carListStyles.loadingText}>
            SCANNING VEHICLE DATABASE...
          </Typography>
        </Box>
      </Box>
    );
  }

  return (
    <>
      {error && (
        <Fade in>
          <Alert
            severity="error"
            sx={carListStyles.errorAlert}
            icon={<MilitaryTech />}
            action={
              <Typography
                variant="body2"
                sx={{ cursor: "pointer", fontWeight: 600 }}
                onClick={refetch}
              >
                Повторить
              </Typography>
            }
          >
            <Typography sx={carListStyles.errorText}>{error}</Typography>
          </Alert>
        </Fade>
      )}

      {cars.length > 0 && (
        <Grid container spacing={2}>
          {cars.map((car, index) => (
            <Fade in timeout={800 + index * 100} key={car.id}>
              <Box sx={carListStyles.cardWrapper}>
                <CarCard car={car} />
              </Box>
            </Fade>
          ))}
        </Grid>
      )}

      {!loading && cars.length === 0 && (
        <Fade in>
          <Box sx={carListStyles.noDataBox}>
            <Typography variant="h6" sx={carListStyles.noDataText}>
              NO VEHICLES FOUND IN DATABASE
            </Typography>
          </Box>
        </Fade>
      )}

      {loading && cars.length > 0 && (
        <Box display="flex" justifyContent="center" py={2}>
          <CircularProgress sx={carListStyles.reloadSpinner} />
        </Box>
      )}

      <ScrollTop>
        <Fab
          size="medium"
          aria-label="scroll back to top"
          sx={carListStyles.scrollFab}
        >
          <KeyboardArrowUp />
        </Fab>
      </ScrollTop>
    </>
  );
};
