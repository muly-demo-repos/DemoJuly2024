/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { InputType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { VerificationTokenWhereInput } from "./VerificationTokenWhereInput";
import { ValidateNested, IsOptional } from "class-validator";
import { Type } from "class-transformer";

@InputType()
class VerificationTokenListRelationFilter {
  @ApiProperty({
    required: false,
    type: () => VerificationTokenWhereInput,
  })
  @ValidateNested()
  @Type(() => VerificationTokenWhereInput)
  @IsOptional()
  @Field(() => VerificationTokenWhereInput, {
    nullable: true,
  })
  every?: VerificationTokenWhereInput;

  @ApiProperty({
    required: false,
    type: () => VerificationTokenWhereInput,
  })
  @ValidateNested()
  @Type(() => VerificationTokenWhereInput)
  @IsOptional()
  @Field(() => VerificationTokenWhereInput, {
    nullable: true,
  })
  some?: VerificationTokenWhereInput;

  @ApiProperty({
    required: false,
    type: () => VerificationTokenWhereInput,
  })
  @ValidateNested()
  @Type(() => VerificationTokenWhereInput)
  @IsOptional()
  @Field(() => VerificationTokenWhereInput, {
    nullable: true,
  })
  none?: VerificationTokenWhereInput;
}
export { VerificationTokenListRelationFilter as VerificationTokenListRelationFilter };