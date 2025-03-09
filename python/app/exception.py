import os
from fastapi import HTTPException

def check_if_model_is_deployed():
     if not os.path.exists("model.pkl"):
        raise HTTPException(status_code=404, detail="No model is deployed!")