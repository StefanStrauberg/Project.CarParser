// src/pages/mainPageStyles.ts
import { alpha } from "@mui/material/styles";
import type { SxProps } from "@mui/material/styles";
import type { Theme } from "@mui/material/styles";

export const styles = {
  container: {
    py: 4,
    position: "relative",
  } as SxProps<Theme>,

  headerBox: {
    textAlign: "center",
    mb: 8,
    position: "relative",
  } as SxProps<Theme>,

  title: {
    mb: 3,
    fontSize: { xs: "2.5rem", md: "4rem" },
    textShadow: "0 4px 20px rgba(99, 102, 241, 0.3)",
  } as SxProps<Theme>,

  subtitle: {
    mb: 6,
    background: "linear-gradient(45deg, #818cf8, #f472b6, #f59e0b)",
    backgroundClip: "text",
    WebkitBackgroundClip: "text",
    WebkitTextFillColor: "transparent",
    fontWeight: 500,
  } as SxProps<Theme>,

  todaySpan: {
    display: "block",
    fontSize: "0.6em",
    background: "linear-gradient(45deg, #818cf8, #f472b6, #f59e0b)",
    backgroundClip: "text",
    WebkitBackgroundClip: "text",
    WebkitTextFillColor: "transparent",
  } as SxProps<Theme>,

  statsWrapper: {
    display: "flex",
    justifyContent: "center",
    gap: 3,
    flexWrap: "wrap",
  } as SxProps<Theme>,

  statBox: (color: string): SxProps<Theme> => ({
    textAlign: "center",
    p: 3,
    background: "rgba(30, 30, 58, 0.6)",
    borderRadius: "20px",
    border: "1px solid",
    borderColor: alpha(color, 0.2),
    backdropFilter: "blur(10px)",
    minWidth: { xs: 120, sm: 140 },
    flex: { xs: 1, sm: "none" },
  }),

  statValue: (color: string): SxProps<Theme> => ({
    fontWeight: 800,
    color,
    textShadow: `0 2px 10px ${alpha(color, 0.3)}`,
    fontSize: { xs: "1.5rem", sm: "2rem" },
  }),

  statLabel: {
    mt: 1,
    color: "text.secondary",
  } as SxProps<Theme>,

  errorAlert: {
    mb: 3,
    borderRadius: "16px",
    background: alpha("#f44336", 0.1),
    border: "1px solid",
    borderColor: alpha("#f44336", 0.2),
    backdropFilter: "blur(10px)",
  } as SxProps<Theme>,

  retryButton: {
    textTransform: "none",
    fontWeight: 500,
  } as SxProps<Theme>,

  loadingWrapper: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    minHeight: "400px",
  } as SxProps<Theme>,

  loadingCircle: {
    color: "primary.main",
    mb: 3,
    background:
      "conic-gradient(from 45deg, #6366f1, #ec4899, #f59e0b, #6366f1)",
    borderRadius: "50%",
    padding: "8px",
  } as SxProps<Theme>,

  loadingText: {
    background: "linear-gradient(45deg, #818cf8, #f472b6)",
    backgroundClip: "text",
    WebkitBackgroundClip: "text",
    WebkitTextFillColor: "transparent",
  } as SxProps<Theme>,

  gridWrapper: {
    display: "grid",
    gridTemplateColumns: {
      xs: "1fr",
      sm: "repeat(2, 1fr)",
      md: "repeat(3, 1fr)",
      lg: "repeat(4, 1fr)",
    },
    gap: 3,
    mx: { xs: 0, sm: -1.5 },
  } as SxProps<Theme>,

  noCarsText: {
    background: "linear-gradient(45deg, #818cf8, #f472b6)",
    backgroundClip: "text",
    WebkitBackgroundClip: "text",
    WebkitTextFillColor: "transparent",
  } as SxProps<Theme>,

  scrollFab: {
    background: "linear-gradient(45deg, #6366f1, #ec4899, #f59e0b)",
    color: "white",
    "&:hover": {
      background: "linear-gradient(45deg, #575bc7, #db2777, #eab308)",
      transform: "scale(1.1)",
    },
    transition: "all 0.3s ease",
    boxShadow: "0 8px 25px rgba(99, 102, 241, 0.4)",
  } as SxProps<Theme>,
};
