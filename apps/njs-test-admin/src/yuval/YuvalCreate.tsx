import * as React from "react";
import { Create, SimpleForm, CreateProps, TextInput } from "react-admin";

export const YuvalCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput label="ald1" source="ald1" />
        <TextInput label="eld1" source="eld1" />
        <TextInput label="eld2" source="eld2" />
        <TextInput label="eld2b" source="eld2b" />
        <TextInput label="fld1" source="fld1" />
      </SimpleForm>
    </Create>
  );
};
