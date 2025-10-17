// src/components/AppBar/index.tsx
import React from "react";
import {
  AppBar,
  Toolbar,
  Box,
  Typography,
  IconButton,
  alpha,
} from "@mui/material";
import { CarRental, Refresh } from "@mui/icons-material";
import GradientText from "../GradientText"; // исправлен импорт

interface AppHeaderProps {
  lastUpdate: Date;
  loading: boolean;
  onRefresh: () => void;
  formatTime: (date: Date) => string;
}

const AppHeader: React.FC<AppHeaderProps> = ({
  lastUpdate,
  loading,
  onRefresh,
  formatTime,
}) => {
  return (
    <AppBar
      position="sticky"
      elevation={0}
      sx={{
        background: alpha("#1a1a2e", 0.9),
        backdropFilter: "blur(20px)",
        borderBottom: `1px solid ${alpha("#6366f1", 0.1)}`,
      }}
    >
      <Toolbar>
        <Box sx={{ display: "flex", alignItems: "center", gap: 2 }}>
          <Box
            sx={{
              background: "linear-gradient(45deg, #6366f1, #ec4899)",
              borderRadius: "12px",
              p: 1,
            }}
          >
            <CarRental sx={{ color: "#fff", fontSize: 28 }} />
          </Box>
          <GradientText variant="h6" sx={{ fontWeight: 700 }}>
            AutoVision
          </GradientText>
        </Box>

        <Box sx={{ flexGrow: 1 }} />

        <Box sx={{ display: "flex", alignItems: "center", gap: 2 }}>
          <Typography
            variant="body2"
            sx={{ display: { xs: "none", sm: "block" }, color: "#fff" }}
          >
            Обновлено: {formatTime(lastUpdate)}
          </Typography>
          <IconButton
            color="inherit"
            onClick={onRefresh}
            disabled={loading}
            sx={{
              transition: "all 0.3s ease",
              "&:hover": {
                background: "linear-gradient(45deg, #6366f1, #ec4899)",
                transform: "rotate(45deg)",
              },
            }}
          >
            <Refresh />
          </IconButton>
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default AppHeader;
