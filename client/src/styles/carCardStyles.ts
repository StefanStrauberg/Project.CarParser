// src/components/carCardStyles.ts
import type { Theme } from "@mui/material/styles";
import type { SxProps } from "@mui/material/styles";
import { alpha } from "@mui/material/styles";

export const carCardStyles = {
  card: {
    height: "100%",
    display: "flex",
    flexDirection: "column",
    cursor: "pointer",
    transition: "all 0.3s cubic-bezier(0.4, 0, 0.2, 1)",
    "&:hover": {
      transform: "translateY(-8px)",
      boxShadow: `
        0 12px 40px rgba(0, 102, 255, 0.3),
        0 6px 20px rgba(255, 68, 68, 0.2)
      `,
      "& .car-image": {
        transform: "scale(1.05)",
      },
    },
  } as SxProps<Theme>,

  topBorder: {
    position: "absolute",
    top: 0,
    left: 0,
    right: 0,
    height: "3px",
    background: "linear-gradient(90deg, #0066ff, #ff4444, #0066ff)",
    zIndex: 2,
  } as SxProps<Theme>,

  imageWrapper: {
    position: "relative",
    overflow: "hidden",
  } as SxProps<Theme>,

  image: {
    transition: "transform 0.3s ease",
    objectFit: "cover",
  } as SxProps<Theme>,

  priceTag: {
    position: "absolute",
    top: 12,
    right: 12,
    background: "linear-gradient(45deg, #0066ff, #ff4444)",
    color: "white",
    px: 2,
    py: 0.5,
    borderRadius: "4px",
    backdropFilter: "blur(10px)",
    border: "1px solid rgba(255, 255, 255, 0.2)",
  } as SxProps<Theme>,

  priceText: {
    fontWeight: 700,
    fontSize: "1.1rem",
    textShadow: "0 1px 2px rgba(0, 0, 0, 0.5)",
  } as SxProps<Theme>,

  engineChip: (background: string, color: string): SxProps<Theme> => ({
    position: "absolute",
    top: 12,
    left: 12,
    background,
    color,
    fontWeight: 600,
    fontSize: "0.75rem",
    height: "24px",
    "& .MuiChip-label": {
      px: 1,
    },
  }),

  content: {
    flexGrow: 1,
    p: 2,
  } as SxProps<Theme>,

  title: {
    fontWeight: 600,
    fontSize: "1rem",
    lineHeight: 1.3,
    mb: 1,
    color: "#ffffff",
    minHeight: "2.6em",
    display: "-webkit-box",
    WebkitLineClamp: 2,
    WebkitBoxOrient: "vertical",
    overflow: "hidden",
  } as SxProps<Theme>,

  specRow: {
    display: "flex",
    alignItems: "center",
    gap: 0.5,
    mb: 0.5,
  } as SxProps<Theme>,

  specIcon: (color: string): SxProps<Theme> => ({
    fontSize: "1rem",
    color,
  }),

  specText: (color: string): SxProps<Theme> => ({
    color,
    fontWeight: 500,
  }),

  locationRow: {
    display: "flex",
    alignItems: "center",
    justifyContent: "space-between",
    pt: 1,
    borderTop: `1px solid ${alpha("#0066ff", 0.2)}`,
  } as SxProps<Theme>,

  locationText: {
    color: alpha("#ffffff", 0.7),
    fontSize: "0.75rem",
  } as SxProps<Theme>,
};
