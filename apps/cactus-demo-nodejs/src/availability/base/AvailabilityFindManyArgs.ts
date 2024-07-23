/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { ArgsType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { AvailabilityWhereInput } from "./AvailabilityWhereInput";
import { IsOptional, ValidateNested, IsInt } from "class-validator";
import { Type } from "class-transformer";
import { AvailabilityOrderByInput } from "./AvailabilityOrderByInput";

@ArgsType()
class AvailabilityFindManyArgs {
  @ApiProperty({
    required: false,
    type: () => AvailabilityWhereInput,
  })
  @IsOptional()
  @ValidateNested()
  @Field(() => AvailabilityWhereInput, { nullable: true })
  @Type(() => AvailabilityWhereInput)
  where?: AvailabilityWhereInput;

  @ApiProperty({
    required: false,
    type: [AvailabilityOrderByInput],
  })
  @IsOptional()
  @ValidateNested({ each: true })
  @Field(() => [AvailabilityOrderByInput], { nullable: true })
  @Type(() => AvailabilityOrderByInput)
  orderBy?: Array<AvailabilityOrderByInput>;

  @ApiProperty({
    required: false,
    type: Number,
  })
  @IsOptional()
  @IsInt()
  @Field(() => Number, { nullable: true })
  @Type(() => Number)
  skip?: number;

  @ApiProperty({
    required: false,
    type: Number,
  })
  @IsOptional()
  @IsInt()
  @Field(() => Number, { nullable: true })
  @Type(() => Number)
  take?: number;
}

export { AvailabilityFindManyArgs as AvailabilityFindManyArgs };