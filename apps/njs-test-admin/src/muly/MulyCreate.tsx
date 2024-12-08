import * as React from "react";
import { Create, SimpleForm, CreateProps, TextInput } from "react-admin";

export const MulyCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput label="aaa" source="aaa" />
        <TextInput label="abc" source="abc" />
        <TextInput label="beck" source="beck" />
        <TextInput label="fox" source="fox" />
        <TextInput label="niver" source="niver" />
        <TextInput label="park" source="park" />
        <TextInput label="zisIsFirst" source="zisIsFirst" />
      </SimpleForm>
    </Create>
  );
};
