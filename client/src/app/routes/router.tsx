import { createBrowserRouter } from "react-router-dom";
import MainPage from "../../pages/MainPage";
import App from "../layouts/App";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <MainPage /> },
      { path: "about", element: <></> },
    ],
  },
]);
