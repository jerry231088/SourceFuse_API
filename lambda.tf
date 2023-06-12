resource "aws_lambda_function" "lambda_function" {
  function_name = "acme_lambda"
  role          = aws_iam_role.lambda.arn
  runtime       = var.runtime
  handler       = "lambda_function.handler"

  source_code_hash = filebase64sha256("lambda_function.zip")

  environment {
     variables = {
       PG_DB_NAME = "ENV_VAR_VALUE"
       PG_DB_USER = "ENV_VAR_VALUE"
       PG_DB_PWD  = "ENV_VAR_VALUE"
       PG_DB_HOST = "ENV_VAR_VALUE"
       PG_DB_PORT = "ENV_VAR_VALUE"
     }
  }

  tags = var.tags
}

resource "aws_cloudwatch_event_rule" "eventbridge_rule" {
  name        = "schedular_rule"
  description = "EventBridge rule for triggering Lambda function"

  schedule_expression = "rate(5 minutes)"
  tags                = var.tags
}

# Create Event source mapping for Lambda function and EventBridge rule
resource "aws_lambda_event_source_mapping" "event_source_mapping" {
  event_source_arn  = aws_cloudwatch_event_rule.eventbridge_rule.arn
  function_name     = aws_lambda_function.lambda_function.function_name
  starting_position = "LATEST"

  batch_size                         = var.batch_size
  maximum_batching_window_in_seconds = var.max_batch_window
}
