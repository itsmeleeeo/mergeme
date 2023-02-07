import RegisterUser from "./components/RegisterUser";
import Login from "./components/Login";
import { Home } from "./components/Home";
import Dashboard from './components/Dashboard'

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/signup',
    element: <RegisterUser />
  },
  {
    path: '/login',
    element: <Login />
  },
  {
    path: '/dashboard',
    element: <Dashboard />
  }
];

export default AppRoutes;
