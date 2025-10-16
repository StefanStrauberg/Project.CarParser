// src/pages/Home.tsx
import { Container, Box } from "@mui/material";
import GradientText from "../components/GradientText";
import { CarList } from "../components/CarList";

export const HomePage: React.FC = () => (
  <Container maxWidth="lg">
    <Box my={4} textAlign="center">
      <GradientText variant="h3">Fast &️ Reliable Cars</GradientText>
    </Box>

    <CarList />
  </Container>
);
