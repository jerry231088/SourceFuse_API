module "acme" {
  source = "../../module/acme?ref=v1.0.0"

  runtime              = "python3.9"
  batch_size           = 10
  max_batch_window     = 60
  log_retention_period = 3

  tags = {
    Name        = "acme"
    Environment = "dev"
    Owner       = "sourcefuse"
    Department  = "data engineering"
    Project     = "sourcefuse_api"
  }
}