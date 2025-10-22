// src/components/GradientChip/index.tsx
import React from "react";
import Chip, { type ChipProps } from "@mui/material/Chip";

export interface GradientChipProps extends Omit<ChipProps, "label"> {
  label: React.ReactNode;
  sx?: ChipProps["sx"];
}

const GradientChip: React.FC<GradientChipProps> = ({ label, sx, ...props }) => (
  <Chip
    label={label}
    sx={{
      background: "linear-gradient(45deg, #6366f1, #818cf8)",
      color: "#fff",
      fontWeight: 600,
      ...sx,
    }}
    {...props}
  />
);

export default GradientChip;
