// src/components/CarList/carListStyles.ts
import type { Theme } from "@mui/material/styles";
import type { SxProps } from "@mui/material/styles";

export const carListStyles = {
  loadingWrapper: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    minHeight: "400px",
  } as SxProps<Theme>,

  loadingCircle: {
    background: "conic-gradient(from 45deg, #0066ff, #ff4444, #0066ff)",
    borderRadius: "50%",
    padding: "8px",
    mb: 2,
    "& .MuiCircularProgress-svg": {
      color: "#00aaff",
    },
  } as SxProps<Theme>,

  loadingText: {
    background: "linear-gradient(45deg, #00aaff, #ff4444)",
    backgroundClip: "text",
    WebkitBackgroundClip: "text",
    WebkitTextFillColor: "transparent",
    fontWeight: 600,
  } as SxProps<Theme>,

  errorAlert: {
    mt: 4,
    mx: "auto",
    maxWidth: 600,
    borderRadius: 2,
    backdropFilter: "blur(10px)",
    backgroundColor: "rgba(50, 0, 0, 0.3)",
    border: "1px solid rgba(255, 68, 68, 0.3)",
    px: 2,
    py: 1.5,
    boxShadow: "0 0 12px rgba(255, 68, 68, 0.2)",
    display: "flex",
    alignItems: "center",
  } as SxProps<Theme>,

  errorText: {
    fontWeight: 600,
    fontSize: "0.9rem",
  } as SxProps<Theme>,

  cardWrapper: {
    width: { xs: "100%", sm: "50%", md: "33.333%" },
    p: 1,
  } as SxProps<Theme>,

  noDataBox: {
    textAlign: "center",
    py: 8,
  } as SxProps<Theme>,

  noDataText: {
    background: "linear-gradient(45deg, #00aaff, #ff4444)",
    backgroundClip: "text",
    WebkitBackgroundClip: "text",
    WebkitTextFillColor: "transparent",
    fontWeight: 600,
    textTransform: "uppercase",
    letterSpacing: "1px",
  } as SxProps<Theme>,

  reloadSpinner: {
    color: "#00aaff",
  } as SxProps<Theme>,

  scrollFab: {
    background: "linear-gradient(45deg, #0066ff, #ff4444)",
    color: "white",
    "&:hover": {
      background: "linear-gradient(45deg, #0055dd, #ff3333)",
      transform: "scale(1.1)",
      boxShadow:
        "0 8px 25px rgba(0, 102, 255, 0.4), 0 5px 15px rgba(255, 68, 68, 0.3)",
    },
    transition: "all 0.3s ease",
    boxShadow: "0 4px 15px rgba(0, 102, 255, 0.3)",
  } as SxProps<Theme>,
};
