// src/components/ScrollTop/index.tsx
import Slide from "@mui/material/Slide";
import Box from "@mui/material/Box";
import useScrollTrigger from "@mui/material/useScrollTrigger";
import type { ReactNode } from "react";

interface ScrollTopProps {
  children: ReactNode; // можно добавить другие props
}

const ScrollTop: React.FC<ScrollTopProps> = ({ children }) => {
  const trigger = useScrollTrigger({
    disableHysteresis: true,
    threshold: 100,
  });

  const handleClick = () => {
    window.scrollTo({ top: 0, behavior: "smooth" });
  };

  return (
    <Slide in={trigger} direction="up">
      <Box
        onClick={handleClick}
        role="presentation"
        sx={{ position: "fixed", bottom: 24, right: 24 }}
      >
        {children}
      </Box>
    </Slide>
  );
};

export default ScrollTop;
