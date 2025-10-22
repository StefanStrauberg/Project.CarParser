// src/pages/MainPage.tsx
import { Box, Container, Fade, Typography, Zoom } from "@mui/material";
import GradientText from "../components/GradientText";
import { styles } from "../styles/mainPageStyles";
import { CarList } from "../components/CarList";
import { useEffect, useState } from "react";

const MainPage = () => {
  const [lastUpdate, setLastUpdate] = useState(new Date());

  useEffect(() => {
    const interval = setInterval(() => {
      setLastUpdate(new Date());
    }, 60000); // обновляем время каждую минуту
    return () => clearInterval(interval);
  }, []);

  const formatTime = (date: Date) =>
    date.toLocaleTimeString("ru-RU", {
      hour: "2-digit",
      minute: "2-digit",
    });

  return (
    <Container maxWidth="xl" sx={styles.container}>
      <Box sx={styles.headerBox}>
        <Fade in timeout={800}>
          <Box>
            <GradientText variant="h1" gutterBottom sx={styles.title}>
              Новые автомобили
              <Box component="span" sx={styles.todaySpan}>
                сегодня
              </Box>
            </GradientText>
          </Box>
        </Fade>

        <Fade in timeout={1000}>
          <Typography variant="h5" sx={styles.subtitle}>
            Самые свежие предложения на рынке • Постоянные обновления
          </Typography>
        </Fade>

        <Fade in timeout={1200}>
          <Box sx={styles.statsWrapper}>
            {[
              { value: "15+", label: "новых авто", color: "#818cf8" },
              { value: "24/7", label: "мониторинг", color: "#f472b6" },
              {
                value: formatTime(lastUpdate),
                label: "последнее обновление",
                color: "#f59e0b",
              },
            ].map((item, index) => (
              <Zoom in timeout={1400 + index * 200} key={item.label}>
                <Box sx={styles.statBox(item.color)}>
                  <Typography variant="h4" sx={styles.statValue(item.color)}>
                    {item.value}
                  </Typography>
                  <Typography variant="body2" sx={styles.statLabel}>
                    {item.label}
                  </Typography>
                </Box>
              </Zoom>
            ))}
          </Box>
        </Fade>
      </Box>

      {/* Вставляем компонент списка автомобилей */}
      <CarList />
    </Container>
  );
};

export default MainPage;
