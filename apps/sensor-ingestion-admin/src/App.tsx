import React, { useEffect, useState } from "react";
import { Admin, DataProvider, Resource } from "react-admin";
import buildGraphQLProvider from "./data-provider/graphqlDataProvider";
import { theme } from "./theme/theme";
import Login from "./Login";
import "./App.scss";
import Dashboard from "./pages/Dashboard";
import { SensorTypeList } from "./sensorType/SensorTypeList";
import { SensorTypeCreate } from "./sensorType/SensorTypeCreate";
import { SensorTypeEdit } from "./sensorType/SensorTypeEdit";
import { SensorTypeShow } from "./sensorType/SensorTypeShow";
import { SensorList } from "./sensor/SensorList";
import { SensorCreate } from "./sensor/SensorCreate";
import { SensorEdit } from "./sensor/SensorEdit";
import { SensorShow } from "./sensor/SensorShow";
import { SensorReadingList } from "./sensorReading/SensorReadingList";
import { SensorReadingCreate } from "./sensorReading/SensorReadingCreate";
import { SensorReadingEdit } from "./sensorReading/SensorReadingEdit";
import { SensorReadingShow } from "./sensorReading/SensorReadingShow";
import { jwtAuthProvider } from "./auth-provider/ra-auth-jwt";

const App = (): React.ReactElement => {
  const [dataProvider, setDataProvider] = useState<DataProvider | null>(null);
  useEffect(() => {
    buildGraphQLProvider
      .then((provider: any) => {
        setDataProvider(() => provider);
      })
      .catch((error: any) => {
        console.log(error);
      });
  }, []);
  if (!dataProvider) {
    return <div>Loading</div>;
  }
  return (
    <div className="App">
      <Admin
        title={"SensorIngestion"}
        dataProvider={dataProvider}
        authProvider={jwtAuthProvider}
        theme={theme}
        dashboard={Dashboard}
        loginPage={Login}
      >
        <Resource
          name="SensorType"
          list={SensorTypeList}
          edit={SensorTypeEdit}
          create={SensorTypeCreate}
          show={SensorTypeShow}
        />
        <Resource
          name="Sensor"
          list={SensorList}
          edit={SensorEdit}
          create={SensorCreate}
          show={SensorShow}
        />
        <Resource
          name="SensorReading"
          list={SensorReadingList}
          edit={SensorReadingEdit}
          create={SensorReadingCreate}
          show={SensorReadingShow}
        />
      </Admin>
    </div>
  );
};

export default App;
