//K.Garnett
//Powerset.java - object class that returns power sets of a string
//9/26/18

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class PowerSet
    {
        public static List<String> getSubset(String nums)
        {

            List<String> result = new ArrayList<String>();
            result.add("[]");

            if(nums!=null && nums.length()>0)
            {
                for (int i = 0; i < nums.length(); i++)
                {
                    List<String> list = new ArrayList<String>();

                    Iterator<String> iter = result.iterator();

                    while(iter.hasNext())
                    {
                        String val = iter.next();

                        if(val.equals("[]"))
                        {
                            list.add("[" + nums.charAt(i) + "]");
                        }
                        else
                            {

                            list.add("[" + val.substring(1,val.length()-1) + ", " + nums.charAt(i) + "]");
                        }
                    }

                    result.addAll(list);
                }
            }

            return result;
        }
    }